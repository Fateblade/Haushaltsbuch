using System.Linq;
using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;
using Fateblade.Haushaltsbuch.Data.DataStoring.Contract;
using Fateblade.Haushaltsbuch.Logic.Domain.SourceManagement.Contract;

namespace Fateblade.Haushaltsbuch.Logic.Domain.SourceManagement
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

        public Source Get(int id)
        {
            return _SourceRepository.Query.First(t => t.Id == id);
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
