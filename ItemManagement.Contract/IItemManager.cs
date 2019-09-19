using System.Linq;
using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;

namespace Fateblade.Haushaltsbuch.Logic.ItemManagement.Contract
{
    public interface IItemManager
    {
        IQueryable<Item> GetItems();
        void Add(Item item);
        void Delete(int id);
        void Update(Item item);
    }
}
