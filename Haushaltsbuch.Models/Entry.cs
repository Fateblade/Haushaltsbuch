using ACI.Base.DB;
using ACI.Base.Usability;
using System;
using System.Collections.Generic;
using System.Text;

namespace Haushaltsbuch.Models
{
    public class Entry : IDataEntity, INotable
    {
        //properties
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int SourceID { get; set; }
        public int ItemID { get; set; }
        public float Amount { get; set; }

        //properties - INotable
        public string Note { get; set; }
    }
}
