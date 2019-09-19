using System;
using System.Linq;
using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;
using Fateblade.Haushaltsbuch.Data.DataStoring.Contract;
using Fateblade.Haushaltsbuch.Logic.EntryManagement.Contract;
using Fateblade.Haushaltsbuch.Logic.EntryManagement.Contract.Exceptions;

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
            try
            {
                _Repository.Add(entry);
            }
            catch (Exception ex)
            {
                throw new CantAddEntryException($"Eintrag konnte nicht hinzugefügt werden", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _Repository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new CantDeleteEntryException($"Eintrag konnte nicht gelöscht werden", ex);
            }
        }

        public IQueryable<Entry> GetEntries()
        {
            return _Repository.Query;
        }

        public void Update(Entry entry)
        {
            try
            {
                _Repository.Update(entry);
            }
            catch (Exception ex)
            {
                throw new CantUpdateEntryException($"Eintrag konnte nicht aktualisiert werden", ex);
            }
        }
    }
}
