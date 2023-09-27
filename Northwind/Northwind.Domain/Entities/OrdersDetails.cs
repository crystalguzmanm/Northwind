using Northwind.Domain.Core;
using System;


namespace Northwind.Domain.Entities
{
    public class OrdersDetails : BaseEntity
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public Decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        
    }
}
