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
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public int ShipperID { get; set; }
        public string? CompanyName { get; set; }
        public string? Phone { get; set; }

        public string? CustomerID { get; set; }
       // public string? PhoneCstm { get; set; } //TODO Repeticionde campos 
        //public string? CompanyNameCstm { get; set; }
        public string? Country { get; set; }
    }
}
