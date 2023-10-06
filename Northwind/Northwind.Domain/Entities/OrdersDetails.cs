using Northwind.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;



namespace Northwind.Domain.Entities
{
    public class OrdersDetails : BaseEntity
    {   
        [Key]
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public Decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        
    }
}
