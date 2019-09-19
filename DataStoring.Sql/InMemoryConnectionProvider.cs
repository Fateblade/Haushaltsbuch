namespace Fateblade.Haushaltsbuch.Data.DataStoring.SqLite
{
    internal class InMemoryConnectionProvider : ISqlLiteConnectionProvider
    {
        public string Connection => @"Data Source=:memory:; Version=3;";
    }
}