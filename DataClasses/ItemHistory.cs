using System;
using System.Collections.Generic;
using System.Text;

namespace Fateblade.Haushaltsbuch.CrossCutting.DataClasses
{

    public class ItemHistory
    {
        //properties
        public int Id { get; set; }
        public DateTime LastBuyDate { get; set; }
        public DateTime DateOfChange { get; set; }

        //DupeID-0001: Item
        public int ItemId { get; set; }
        public string Name { get; set; }
        public decimal PricePerUnit { get; set; }
        public string Note { get; set; }
    }
}
