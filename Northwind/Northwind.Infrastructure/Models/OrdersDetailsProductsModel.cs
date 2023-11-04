using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Infrastructure.Models
{
    public class OrdersDetailsProductsModel
    {
        public int OrderDetailsID { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? QuantityPerUnit { get; set; }
        public short? UnitsInStock { get; set; }
    }
}
