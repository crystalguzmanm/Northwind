using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Infrastructure.Models
{
    public class OrdersEmployeesModel
    {
        public int OrderID { get; set; }
        public string? ShipName { get; set; }
        public string? ShipCity { get; set; }
        public int EmployeeID { get; set; }

        public int LastName { get; set; }

        public string FirstName { get; set; }
    }
}
