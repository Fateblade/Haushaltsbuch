using ACI.Base.DB;
using ACI.Base.Usability;

namespace Haushaltsbuch.Models
{
    public class Item : IDataEntity, INotable
    {
        //properties
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal PricePerUnit { get; set; }

        //properties - INotable
        public string Note { get; set; }
    }
}
