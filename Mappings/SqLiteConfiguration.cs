using Fateblade.Haushaltsbuch.Data.DataStoring.SqLite;
using System;
using System.IO;

namespace Infrastructure.Mappings
{
    class SqLiteFileConfiguration : ISqlLiteConnectionProvider
    {
        public string Connection => $"Data Source:{Path.Combine(Environment.CurrentDirectory, "budget.db")}; Version=3;"; 
    }

    class SqLiteMemoryConfiguration: ISqlLiteConnectionProvider
    {
        public string Connection => @"Data Source=:memory:; Version=3;";
    }
}
