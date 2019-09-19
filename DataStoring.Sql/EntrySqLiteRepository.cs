using DavidTielke.PersonManagementApp.CrossCutting.CoCo.Core.Contract.EventBrokerage;
using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;
using Fateblade.Haushaltsbuch.Data.DataStoring.Contract;
using Fateblade.Haushaltsbuch.Data.DataStoring.Contract.Callbacks;
using Fateblade.Haushaltsbuch.Data.DataStoring.Contract.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Fateblade.Haushaltsbuch.Data.DataStoring.SqLite
{
    public class EntrySqLiteRepository : SqLiteBaseRepository, IEntryRepository
    {
        //properties
        public DbSet<Entry> Entrys { get; set; }
        IQueryable<Entry> IEntryRepository.Query => Entrys.AsQueryable();



        //ctors
        public EntrySqLiteRepository(ISqlLiteConnectionProvider connectionProvider, IEventBroker eventBroker)
           : base(connectionProvider, eventBroker) { }
        public EntrySqLiteRepository(ISqlLiteConnectionProvider connectionProvider)
            : base(connectionProvider) { }
        public EntrySqLiteRepository()
            : base() { }




        //public methods
        public void Add(Entry entry)
        {
            if (entry == null) { throw new ArgumentException(nameof(entry)); }
            bool elementExistsInDatabase = Entrys.FirstOrDefault(t => t.Id == entry.Id) != default;
            if (elementExistsInDatabase) { throw new DataDuplicationException($"Eintrag kann nicht hinzugefügt werden, da er sich bereits in der Datenbank befindet"); }

            Entrys.Add(entry);
            SaveChanges();

            RaiseMessageIfEventBrokerIsAttached(new AddedEntryDataMessage(entry));
        }

        public void Update(Entry entry)
        {
            if (entry == null) { throw new ArgumentException(nameof(entry)); }
            bool elementExistsInDatabase = Entrys.FirstOrDefault(t => t.Id == entry.Id) != default;
            if (!elementExistsInDatabase) { throw new DataMissingException($"Eintrag kann nicht aktualisiert werden, da er sich noch nicht in der Datenbank befindet"); }

            var oldState = Entrys.First(t => t.Id == entry.Id);

            Entrys.Update(entry);
            SaveChanges();

            RaiseMessageIfEventBrokerIsAttached(new UpdatedEntryDataMessage(oldState, entry));
        }

        public void Delete(int id)
        {

            bool elementExistsInDatabase = Entrys.FirstOrDefault(t => t.Id == id) != default;
            if (!elementExistsInDatabase) { throw new DataMissingException($"Eintrag konnte nicht gelöscht werden, da er sich nicht in der Datenbank befindet"); }

            Entry entryToDelete = Entrys.First(t => t.Id == id);
            Entrys.Remove(entryToDelete);
            SaveChanges();

            RaiseMessageIfEventBrokerIsAttached(new DeletedEntryDataMessage(entryToDelete));
        }



        //overrides
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlite(ConnectionProvider.Connection);

                // Info: Powershell to generate migration: dotnet ef migrations add [NameOfMigration] --startup-project "..\Haushaltsbuch.MigrationConsole" --context EntrySqLiteRepository
                Database.Migrate(); //comment out for migration generation

                base.OnConfiguring(optionsBuilder);
            }
            catch (Exception ex)
            {
                throw new DataSourceInitializeException("Fehler beim Konfigurieren der Datenbank", ex);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<Entry>()
                    .Property(p => p.Date).IsRequired();
                modelBuilder.Entity<Entry>()
                    .Property(p => p.Amount).IsRequired();
                modelBuilder.Entity<Entry>()
                    .Property(p => p.ItemID).IsRequired();
                modelBuilder.Entity<Entry>()
                    .Property(p => p.SourceID).IsRequired();
            }
            catch (Exception ex) when (!(ex is DataStoringException))
            {
                throw new DataSourceInitializeException("Fehler beim Generieren des Datenbankmodels", ex);
            }
        }
    }
}
