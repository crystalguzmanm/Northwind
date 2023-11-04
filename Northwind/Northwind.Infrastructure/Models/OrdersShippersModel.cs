using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Infrastructure.Models
{
    public class OrdersShippersModel
    {
        public int OrderID { get; set; }
        public string? ShipName { get; set; }
        public string? ShipCity { get; set; }
        public int ShipperID { get; set; }
        public string? CompanyName { get; set; }

        public string? Phone { get; set; }
    }
}
