using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;
using Fateblade.Haushaltsbuch.Data.DataStoring.Contract;
using Fateblade.Haushaltsbuch.Logic.EntryManagement.Contract;
using System.Linq;

namespace Fateblade.Haushaltsbuch.Logic.EntryManagement
{
    public class EntryManager : IEntryManager
    {
        //members
        private readonly IEntryRepository _Repository;



        //ctors
        public EntryManager(IEntryRepository repository)
        {
            _Repository = repository;
        }



        //public methods
        public void Add(Entry entry)
        {
            _Repository.Add(entry);
        }

        public void Delete(int id)
        {
            _Repository.Delete(id);
        }

        public IQueryable<Entry> GetEntries()
        {
            return _Repository.Query;
        }

        public void Update(Entry entry)
        {
            _Repository.Update(entry);
        }
    }
}
