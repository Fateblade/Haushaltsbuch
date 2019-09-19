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
    public class SourceSqLiteRepository : SqLiteBaseRepository, ISourceRepository
    {
        //properties
        public DbSet<Source> Sources { get; set; }
        IQueryable<Source> ISourceRepository.Query => Sources.AsQueryable();



        //constructors
        public SourceSqLiteRepository(ISqlLiteConnectionProvider connectionProvider, IEventBroker eventBroker) 
            : base(connectionProvider, eventBroker) { }
        public SourceSqLiteRepository(ISqlLiteConnectionProvider connectionProvider) 
            : base(connectionProvider) { }
        public SourceSqLiteRepository()
            : base() { }



        //public methods        
        public void Add(Source source)
        {
            if (source == null) { throw new ArgumentNullException(nameof(source)); }
            bool elementExistsInDatabase = Sources.FirstOrDefault(t => t.Id == source.Id) != default;
            if (elementExistsInDatabase) { throw new DataDuplicationException($"Quelle mit der Id '{source.Id}' kann nicht hinzugefügt werden da sie bereits existiert"); }

            Sources.Add(source);
            SaveChanges();

            RaiseMessageIfEventBrokerIsAttached(new AddedSourceDataMessage(source));
        }
        public void Update(Source source)
        {
            if (source == null) { throw new ArgumentNullException(nameof(source)); }
            bool elementExistsInDatabase = Sources.FirstOrDefault(t => t.Id == source.Id) != default;
            if (!elementExistsInDatabase) { throw new DataMissingException($"Quelle kann nicht aktualisiert werden, da sie noch nicht in der Datenbank existiert"); }

            var originalSource = Sources.First(t => t.Id == source.Id);

            Sources.Update(source);
            SaveChanges();

            RaiseMessageIfEventBrokerIsAttached(new UpdatedSourceDataMessage(originalSource, source));
        }
        public void Delete(int id)
        {
            bool elementExistsInDatabase = Sources.FirstOrDefault(t => t.Id == id) != default;
            if (!elementExistsInDatabase) { throw new DataMissingException($"Quelle mit der Id '{id}' kann nicht gelöscht werden da sie nicht in der Datenbank existiert"); }

            var sourceToDelete = Sources.First(t => t.Id == id);
            Sources.Remove(sourceToDelete);
            SaveChanges();

            RaiseMessageIfEventBrokerIsAttached(new DeletedSourceDataMessage(sourceToDelete));
        }



        //overrides
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlite(ConnectionProvider.Connection);
                // Todo: lookup https://go.microsoft.com/fwlink/?linkid=851728
                // Info: Powershell to generate migration: dotnet ef migrations add [NameOfMigration] --startup-project "..\Haushaltsbuch.MigrationConsole" --context SourceSqLiteRepository
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
                modelBuilder.Entity<ItemHistory>().Property(p => p.PricePerUnit).IsRequired();
                modelBuilder.Entity<ItemHistory>().Property(p => p.Name).IsRequired();

            }
            catch (Exception ex)
            {
                throw new DataSourceInitializeException("Fehler beim Generieren des Datenbankmodels", ex);
            }
        }

    }
}
