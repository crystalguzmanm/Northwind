namespace Northwind.API.Models.Core
{
    public class OrdersDetailsBaseModel
    {
        public int OrderDetailsID { get; set; }
        public int ProductID { get; set; }
        public Decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        public DateTime CreationDate { get; set; }

        public int CreationUser { get; set; }

        public DateTime? ModifyDate { get; set; }
    }
}
