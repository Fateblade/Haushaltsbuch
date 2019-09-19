using System;

namespace Fateblade.Haushaltsbuch.CrossCutting.DataClasses
{
    public class Entry
    {
        //properties
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int SourceID { get; set; }
        public int ItemID { get; set; }
        public float Amount { get; set; }
        public string Note { get; set; }
    }
}
