using System.Linq;
using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;

namespace Fateblade.Haushaltsbuch.Logic.EntryManagement.Contract
{
    public interface IEntryManager
    {
        IQueryable<Entry> GetEntries();
        void Add(Entry entry);
        void Delete(int id);
        void Update(Entry entry);
    }
}
