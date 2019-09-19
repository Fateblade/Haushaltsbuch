using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;
using Fateblade.Haushaltsbuch.Data.DataStoring.Contract;
using Fateblade.Haushaltsbuch.Logic.EntryManagement.Contract;
using System.Linq;

namespace Fateblade.Haushaltsbuch.Logic.EntryManagement
{
    public class EntryManager : IEntryManager
    {
        //members
        private readonly IEntryRepository _EntryRepository;



        //ctors
        public EntryManager(IEntryRepository repository)
        {
            _EntryRepository = repository;
        }



        //public methods
        public void Add(Entry entry)
        {
            _EntryRepository.Add(entry);
        }

        public void Delete(int id)
        {
            _EntryRepository.Delete(id);
        }

        public Entry Get(int id)
        {
            return _EntryRepository.Query.First(t => t.Id == id);
        }

        public IQueryable<Entry> GetEntries()
        {
            return _EntryRepository.Query;
        }

        public void Update(Entry entry)
        {
            _EntryRepository.Update(entry);
        }
    }
}
