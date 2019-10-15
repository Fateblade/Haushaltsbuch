using System.Linq;
using Fateblade.Haushaltsbuch.CrossCutting.DataClasses;
using Fateblade.Haushaltsbuch.Data.DataStoring.Contract;
using Fateblade.Haushaltsbuch.Logic.Domain.BillManagement.Contract;

namespace Fateblade.Haushaltsbuch.Logic.Domain.BillManagement
{
    public class BillManager : IBillManager
    {
        //members
        private readonly IBillRepository _BillRepository;

        

        //ctors
        public BillManager(IBillRepository billRepository)
        {
            _BillRepository = billRepository;
        }



        //public methods
        public void Add(Bill item)
        {
            _BillRepository.Add(item);
        }

        public void Delete(int id)
        {
            _BillRepository.Delete(id);
        }

        public Bill Get(int id)
        {
            return _BillRepository.Query.First(t => t.Id == id);
        }

        public IQueryable<Bill> GetItems()
        {
            return _BillRepository.Query;
        }

        public void Update(Bill item)
        {
            _BillRepository.Update(item);
        }
    }
}
