using System;

namespace Northwind.Application.DTOs.Customers
{
    public class CustomersDtoUpdate : CustomersDtoBase
    {
        public int ID { get; set; }

        public DateTime ModifyDate { get; set; }

        public DateTime EnrollmentDate { get; set; }
    }
}
