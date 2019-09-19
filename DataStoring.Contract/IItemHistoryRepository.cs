using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;
using System.Linq;

namespace Fateblade.Haushaltsbuch.Data.DataStoring.Contract
{
    public interface IItemHistoryRepository
    {
        IQueryable<ItemHistory> Query { get; }
        ItemHistory Get(int id);
        void Delete(int id);
        void Add(ItemHistory history);
        
    }
}
