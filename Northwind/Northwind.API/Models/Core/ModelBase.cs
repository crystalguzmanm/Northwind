namespace Northwind.API.Models.Core
{
    public class ModelBase
    {
        public int ChangeUser { get; set; }
        public DateTime ChanageDate { get; set; }
        public string? ShipCity { get; set; }
        public DateTime ChangeModifyDate { get; set; }
        public string? ShipName { get; set; }
        public int OrderDetailsID { get; set; }
        public short Quantity { get; set; }
        public int ProductID { get; set; }

    }
}
