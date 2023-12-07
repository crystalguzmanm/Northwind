using Microsoft.Extensions.Configuration;
using System;

namespace Northwind.Application.DTOs.Customers
{
    public class CustomersDtoUpdate : CustomersDtoBase
    { 

        public CustomersDtoUpdate(IConfiguration configuration) : base(configuration)
        {

        }

        public int CustomerID { get; set; }

        public DateTime ModifyDate { get; set; }
    }
}
