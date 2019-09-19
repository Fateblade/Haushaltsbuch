using System;
using System.Collections.Generic;

namespace Fateblade.Haushaltsbuch.CrossCutting.DataClasses
{
    public class Bill
    {
        //properties
        public int Id { get; set; }
        public List<int> BoughtEntryIds { get; set; }
        public decimal SumPaid { get; set; }
        public DateTime BuyDate { get; set; }
        public int BoughtAtSourceId { get; set; }
        public string Note { get; set; }
    }
}
