using System;
using System.Linq;
using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;
using Fateblade.Haushaltsbuch.Data.DataStoring.Contract;
using Fateblade.Haushaltsbuch.Logic.ItemManagement.Contract;
using Fateblade.Haushaltsbuch.Logic.ItemManagement.Contract.Exceptions;

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
            try
            {
                _ItemRepository.Add(item);
            }
            catch(Exception ex)
            {
                throw new CantAddItemException("Gegenstand konnte nicht hinzugefügt werden", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _ItemRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new CantDeleteItemException("Gegenstand konnte nicht gelöscht werden", ex);
            }
        }

        public IQueryable<Item> GetItems()
        {
            return _ItemRepository.Query;
        }

        public void Update(Item item)
        {
            try
            {
                _ItemRepository.Update(item);
            }
            catch (Exception ex)
            {
                throw new CantUpdateItemException("Gegenstand konnte nicht aktualisiert werden", ex);
            }
        }
    }
}
