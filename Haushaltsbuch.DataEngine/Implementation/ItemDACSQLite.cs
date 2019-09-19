using Haushaltsbuch.Models;
using System;
using System.Collections.Generic;

namespace Haushaltsbuch.DataEngine.Implementation
{
    public class ItemDACSQLite : DataExecutionEngine<Item>, IItemDAC
    {
        //constructors
        public ItemDACSQLite()
        {
        }

        public ItemDACSQLite(string dbFilePath) : base(dbFilePath)
        {
        }



        //public methods
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Item Get()
        {
            throw new NotImplementedException();
        }

        public List<Item> GetList()
        {
            throw new NotImplementedException();
        }

        public Item Save(Item toSave)
        {
            throw new NotImplementedException();
        }
    }
}
