using Haushaltsbuch.Models;
using System;
using System.Collections.Generic;

namespace Haushaltsbuch.DataEngine.Implementation
{
    public class EntryDACSQLite : DataExecutionEngine<Entry>, IEntryDAC
    {
        //constructors
        public EntryDACSQLite()
        {
        }
        public EntryDACSQLite(string dbFilePath) : base(dbFilePath)
        {
        }



        //public members
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Entry Get()
        {
            throw new NotImplementedException();
        }

        public List<Entry> GetList()
        {
            throw new NotImplementedException();
        }

        public Entry Save(Entry toSave)
        {
            throw new NotImplementedException();
        }
    }
}
