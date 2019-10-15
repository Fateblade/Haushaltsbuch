using System.Linq;
using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;
using Fateblade.Haushaltsbuch.Data.DataStoring.Contract;
using Fateblade.Haushaltsbuch.Logic.Domain.ItemHistoryManagement.Contract;

namespace Fateblade.Haushaltsbuch.Logic.Domain.ItemHistoryManagement
{
    public class ItemHistoryManager : IItemHistoryManager
    {
        //members
        private readonly IItemHistoryRepository _ItemHistoryRepository;



        //ctors
        public ItemHistoryManager(IItemHistoryRepository itemHistoryRepository)
        {
            _ItemHistoryRepository = itemHistoryRepository;
        }



        //public methods
        public void Add(ItemHistory item)
        {
            _ItemHistoryRepository.Add(item);
        }

        public void Delete(int id)
        {
            _ItemHistoryRepository.Delete(id);
        }

        public ItemHistory Get(int historyId)
        {
            return _ItemHistoryRepository.Query.First(t => t.Id == historyId);
        }

        public IQueryable<ItemHistory> GetHistoryOfItem(int itemId)
        {
            return _ItemHistoryRepository.Query.Where(t => t.ItemId == itemId);
        }

        public IQueryable<ItemHistory> GetItemHistories()
        {
            return _ItemHistoryRepository.Query;
        }
    }
}
