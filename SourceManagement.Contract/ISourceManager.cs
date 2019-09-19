using System.Linq;
using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;

namespace Fateblade.Haushaltsbuch.Logic.SourceManagement.Contract
{
    public interface ISourceManager
    {
        IQueryable<Source> GetSources();
        void Add(Source source);
        void Delete(int id);
        void Update(Source source);
    }
}
