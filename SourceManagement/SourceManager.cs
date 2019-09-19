using System;
using System.Linq;
using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;
using Fateblade.Haushaltsbuch.Data.DataStoring.Contract;
using Fateblade.Haushaltsbuch.Logic.SourceManagement.Contract;
using Fateblade.Haushaltsbuch.Logic.SourceManagement.Contract.Exceptions;

namespace Fateblade.Haushaltsbuch.Logic.SourceManagement
{
    public class SourceManager : ISourceManager
    {
        //members
        private readonly ISourceRepository _SourceRepository;



        //ctors
        public SourceManager(ISourceRepository sourceRepository)
        {
            _SourceRepository = sourceRepository;
        }



        //public methods
        public void Add(Source source)
        {
            try
            {
                _SourceRepository.Add(source);
            }
            catch (Exception ex)
            {
                throw new CantAddSourceException("Quelle konnte nicht hinzugefügt werden", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _SourceRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new CantDeleteSourceException("Quelle konnte nicht gelöscht werden", ex);
            }
        }

        public IQueryable<Source> GetSources()
        {
            return _SourceRepository.Query;
        }

        public void Update(Source source)
        {
            try
            {
                _SourceRepository.Update(source);
            }
            catch (Exception ex)
            {
                throw new CantUpdateSourceException("Quelle konnte nicht aktualisiert werden", ex);
            }
        }
    }
}
