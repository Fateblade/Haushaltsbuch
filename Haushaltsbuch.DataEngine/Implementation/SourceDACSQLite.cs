using Haushaltsbuch.Models;
using System;
using System.Collections.Generic;

namespace Haushaltsbuch.DataEngine.Implementation
{
    public class SourceDACSQLite : DataExecutionEngine<Source>, IEntryDAC
    {
        //constructors
        public SourceDACSQLite()
        {
        }

        public SourceDACSQLite(string dbFilePath) : base(dbFilePath)
        {
        }



        //public methods
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
