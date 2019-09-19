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
    public class ItemSqLiteRepository : SqLiteBaseRepository, IItemRepository
    {
        //properties
        public DbSet<Item> Items { get; set; }
        IQueryable<Item> IItemRepository.Query => Items.AsQueryable();




        //ctors
        public ItemSqLiteRepository(ISqlLiteConnectionProvider connectionProvider, IEventBroker eventBroker)
            : base(connectionProvider, eventBroker) { }
        public ItemSqLiteRepository(ISqlLiteConnectionProvider connectionProvider)
            : base(connectionProvider) { }
        public ItemSqLiteRepository()
            : base() { }



        //public methods
        public void Add(Item item)
        {
            if (item == null) { throw new ArgumentException(nameof(item)); }
            bool elementExistsInDatabase = Items.FirstOrDefault(t => t.Id == item.Id) != default;
            if (elementExistsInDatabase) { throw new DataDuplicationException($"Gegenstand kann nicht hinzugefügt werden, da er sich bereits in der Datenbank befindet"); }

            Items.Add(item);
            SaveChanges();

            RaiseMessageIfEventBrokerIsAttached(new AddedItemDataMessage(item));
        }

        public void Update(Item item)
        {
            if (item == null) { throw new ArgumentException(nameof(item)); }
            bool elementExistsInDatabase = Items.FirstOrDefault(t => t.Id == item.Id) != default;
            if (!elementExistsInDatabase) { throw new DataMissingException($"Gegenstand kann nicht aktualisiert werden, da er noch nicht in der Datenbank existiert"); }

            var oldItem = Items.First(t => t.Id == item.Id);
            Items.Update(item);
            SaveChanges();

            RaiseMessageIfEventBrokerIsAttached(new UpdatedItemDataMessage(oldItem,item));
        }

        public void Delete(int id)
        {
            bool elementExistsInDatabase = Items.FirstOrDefault(t => t.Id == id) != default;
            if (!elementExistsInDatabase) { throw new DataMissingException($"Gegenstand mit der Id '{id}' kann nicht gelöscht werden da er nicht in der Datenbank existiert"); }

            Item itemToDelete = Items.First(t => t.Id == id);
            Items.Remove(itemToDelete);
            SaveChanges();

            RaiseMessageIfEventBrokerIsAttached(new DeletedItemDataMessage(itemToDelete));
        }



        //overrides
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlite(ConnectionProvider.Connection);

                // Info: // Info: Powershell to generate migration: dotnet ef migrations add [NameOfMigration] --startup-project "..\Haushaltsbuch.MigrationConsole" --context ItemSqLiteRepository
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

                modelBuilder.Entity<Item>()
                    .Property(p => p.PricePerUnit).IsRequired();
                modelBuilder.Entity<Item>()
                    .Property(p => p.Name).IsRequired();
            }
            catch (Exception ex) when (!(ex is DataStoringException))
            {
                throw new DataSourceInitializeException("Fehler beim Generieren des Datenbankmodels", ex);
            }
        }
    }
}
