namespace Fateblade.Haushaltsbuch.CrossCutting.DataClasses
{
    //DupeID-0001: Item
    public class Item
    {
        //properties
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PricePerUnit { get; set; }
        public string Note { get; set; }
    }
}
