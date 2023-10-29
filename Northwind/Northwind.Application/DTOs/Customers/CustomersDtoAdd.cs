using System;

namespace Northwind.Application.DTOs.Customers
{
    public class CustomersDtoAdd : CustomersDtoBase
    {
        public DateTime EnrollmentDate { get; set; }
    }
}
