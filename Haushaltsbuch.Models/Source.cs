using ACI.Base.DB;
using ACI.Base.Usability;

namespace Haushaltsbuch.Models
{
    public class Source : IDataEntity, INotable
    {
        //properties
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        //properties - INotable
        public string Note { get; set; }
    }
}
