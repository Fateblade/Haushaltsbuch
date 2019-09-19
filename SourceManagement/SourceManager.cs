using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;
using Fateblade.Haushaltsbuch.Data.DataStoring.Contract;
using Fateblade.Haushaltsbuch.Logic.SourceManagement.Contract;
using System.Linq;

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
            _SourceRepository.Add(source);
        }

        public void Delete(int id)
        {
            _SourceRepository.Delete(id);
        }

        public IQueryable<Source> GetSources()
        {
            return _SourceRepository.Query;
        }

        public void Update(Source source)
        {
            _SourceRepository.Update(source);
        }
    }
}
