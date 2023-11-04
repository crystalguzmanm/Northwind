using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Infrastructure.Models
{
    public class OrdersCustomersModel
    {
        public int OrderID { get; set; }
        public string? ShipName { get; set; }
        public string? ShipCity { get; set; }
        public string? CustomerID { get; set; }
        public string? Phone { get; set; }
        public string? CompanyName { get; set; }
        public string? Country { get; set; }
    }
}
