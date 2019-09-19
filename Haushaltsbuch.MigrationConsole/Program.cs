using Fateblade.Haushaltsbuch.Data.DataStoring.SqLite;
using System;
using System.IO;

namespace Haushaltsbuch.MigrationConsole
{
    class Program
    {
        public class ConnectionProvider : ISqlLiteConnectionProvider
        {
            public string Connection => $"Data Source:{Path.Combine(Environment.CurrentDirectory, "budget.db")}; Version=3;";
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var entryContext = new EntrySqLiteRepository(new ConnectionProvider());
            var sourceContext = new SourceSqLiteRepository(new ConnectionProvider());
            var itemContext = new ItemSqLiteRepository(new ConnectionProvider());
            var billContext = new BillSqLiteRepository(new ConnectionProvider());

        }
    }
}
