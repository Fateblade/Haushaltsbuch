using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;
using Fateblade.Haushaltsbuch.Data.DataStoring.Contract;
using Fateblade.Haushaltsbuch.Logic.ItemManagement.Contract;
using System.Linq;

namespace Fateblade.Haushaltsbuch.Logic.ItemManagement
{
    public class ItemManager : IItemManager
    {
        //members
        private readonly IItemRepository _ItemRepository;



        //ctors
        public ItemManager(IItemRepository itemRepository)
        {
            _ItemRepository = itemRepository;
        }



        //public methods
        public void Add(Item item)
        {
            _ItemRepository.Add(item);
        }

        public void Delete(int id)
        {
            _ItemRepository.Delete(id);
        }

        public Item Get(int id)
        {
            return _ItemRepository.Query.First(t => t.Id == id);
        }

        public IQueryable<Item> GetItems()
        {
            return _ItemRepository.Query;
        }

        public void Update(Item item)
        {
            _ItemRepository.Update(item);
        }
    }
}
