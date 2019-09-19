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
    public class BillSqLiteRepository : SqLiteBaseRepository, IBillRepository
    {
        //properties
        public DbSet<Bill> Bills { get; set; }
        IQueryable<Bill> IBillRepository.Query => Bills.AsQueryable();



        //constructors
        public BillSqLiteRepository(ISqlLiteConnectionProvider connectionProvider, IEventBroker eventBroker)
           : base(connectionProvider, eventBroker) { }
        public BillSqLiteRepository(ISqlLiteConnectionProvider connectionProvider)
            : base(connectionProvider) { }
        public BillSqLiteRepository()
            : base() { }



        //public method
        public void Add(Bill bill)
        {
            if (bill == null) { throw new ArgumentNullException(nameof(bill)); }
            bool elementExistsInDatabase = Bills.FirstOrDefault(t => t.Id == bill.Id)!=default;
            if (elementExistsInDatabase) { throw new DataDuplicationException($"Rechnung kann nicht neu hinzugefügt werden, da sie sich bereits in der Datenbank befindet."); }

            Bills.Add(bill);
            SaveChanges();


            RaiseMessageIfEventBrokerIsAttached(new AddedBillDataMessage(bill));
        }

        public void Delete(int id)
        {
            bool elementExistsInDatabase = Bills.FirstOrDefault(t => t.Id == id) != default;
            if (!elementExistsInDatabase) { throw new DataMissingException($"Rechnung kann nicht gelöscht werden, da sie nicht in der Datenbank gefunden wurde"); }

            var billToRemove = Bills.First(t => t.Id == id);

            Bills.Remove(billToRemove);
            SaveChanges();

            RaiseMessageIfEventBrokerIsAttached(new DeletedBillDataMessage(billToRemove));
        }

        public void Update(Bill bill)
        {
            if (bill == null) { throw new ArgumentNullException(nameof(bill)); }
            bool elementExistsInDatabase = Bills.FirstOrDefault(t => t.Id == bill.Id) != default;
            if (!elementExistsInDatabase) { throw new DataMissingException($"Änderungen an der Rechnung können nicht gespeichert werden, da sie sich nicht in der Datenbank befindet"); }

            var oldStateOfBill = Bills.First(t => t.Id == bill.Id);

            Bills.Update(bill);
            SaveChanges();

            RaiseMessageIfEventBrokerIsAttached(new UpdatedBillDataMessage(oldStateOfBill, bill));
        }



        //overwrites
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlite(ConnectionProvider.Connection);
                
                // Info: // Info: Powershell to generate migration: dotnet ef migrations add [NameOfMigration] --startup-project "..\Haushaltsbuch.MigrationConsole" --context BillSqLiteRepository
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

                modelBuilder.Entity<Bill>()
                    .Property(p => p.BuyDate).IsRequired();
                // Todo: nachlesen wie das mit dem mapping über eine kreuztabelle in ef funktioniert
                modelBuilder.Entity<Bill>().Ignore(p => p.BoughtEntryIds);
                modelBuilder.Entity<Bill>()
                    .Property(p => p.BoughtAtSourceId).IsRequired();
                modelBuilder.Entity<Bill>()
                    .Property(p => p.SumPaid).IsRequired();
            }
            catch (Exception ex) when (!(ex is DataStoringException))
            {
                throw new DataSourceInitializeException("Fehler beim Generieren des Datenbankmodels", ex);
            }
        }
    }
}
