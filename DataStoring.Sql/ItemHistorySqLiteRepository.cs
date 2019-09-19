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
    public class ItemHistorySqLiteRepository : SqLiteBaseRepository, IItemHistoryRepository
    {
        //properties
        DbSet<ItemHistory> ItemHistories { get; set; }
        IQueryable<ItemHistory> IItemHistoryRepository.Query => ItemHistories.AsQueryable();



        //constructors
        public ItemHistorySqLiteRepository() { }
        public ItemHistorySqLiteRepository(ISqlLiteConnectionProvider connectionProvider) 
            : base(connectionProvider) { }

        public ItemHistorySqLiteRepository(ISqlLiteConnectionProvider connectionProvider, IEventBroker eventBroker) 
            : base(connectionProvider, eventBroker) { }



        //public methods
        public void Add(ItemHistory history)
        {
            if(history == null) { throw new ArgumentException(nameof(history)); }
            bool elementExistsInDatabase = ItemHistories.FirstOrDefault(t => t.Id == history.Id) != default;
            if (elementExistsInDatabase) { throw new DataDuplicationException($"Gegenstandshistorie kann nicht angelegt werden, da sie bereits existiert"); }

            ItemHistories.Add(history);
            SaveChanges();

            RaiseMessageIfEventBrokerIsAttached(new AddedItemHistoryDataMessage(history));
        }

        public ItemHistory Get(int id)
        {
            bool elementExistsInDatabase = ItemHistories.FirstOrDefault(t => t.Id == id) != default;
            if (!elementExistsInDatabase) { throw new DataMissingException($"Gegenstandshistorie mit Id {id} existiert nicht in der Datenbank"); }

            return ItemHistories.First(t => t.Id == id);
        }

        public void Delete(int id)
        {
            bool elementExistsInDatabase = ItemHistories.FirstOrDefault(t => t.Id == id) != default;
            if (!elementExistsInDatabase) { throw new DataMissingException($"Gegenstandshistorie mit Id {id} kann nicht gelöscht werden, da er nicht in der Datenbank existiert"); }

            ItemHistory historyToDelete = ItemHistories.First(t => t.Id == id);
            ItemHistories.Remove(historyToDelete);
            SaveChanges();

            RaiseMessageIfEventBrokerIsAttached(new DeletedItemHistoryDataMessage(historyToDelete));
        }



        //overwrites
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlite(ConnectionProvider.Connection);
                // Todo: lookup https://go.microsoft.com/fwlink/?linkid=851728
                // Info: Powershell to generate migration: dotnet ef migrations add [NameOfMigration] --startup-project "..\Haushaltsbuch.MigrationConsole" --context ItemHistorySqLiteRepository
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

                modelBuilder.Entity<ItemHistory>()
                    .Property(p => p.ItemId).IsRequired();
                modelBuilder.Entity<ItemHistory>()
                    .Property(p => p.PricePerUnit).IsRequired();
                modelBuilder.Entity<ItemHistory>()
                    .Property(p => p.Name).IsRequired();
            }
            catch (Exception ex)
            {
                throw new DataSourceInitializeException("Fehler beim Generieren des Datenbankmodels", ex);
            }
        }
    }
}
