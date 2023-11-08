

using System;

namespace Northwind.Application.DTOs.Customers
{
    public class CustomersDtoGetAll  
    {
        public string? CompanyName { get; set; }

        public string? City { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }
        public int CustomerID { get; set; }
        public int CreationUser { get; set; }

        public DateTime? ModifyDate { get; set; }
    }
}
