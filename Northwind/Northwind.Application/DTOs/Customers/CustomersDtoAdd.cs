using Microsoft.Extensions.Configuration;
using System;

namespace Northwind.Application.DTOs.Customers
{
    public class CustomersDtoAdd : CustomersDtoBase
    {
        public CustomersDtoAdd(IConfiguration configuration) : base(configuration)
        { 
        
        }
        
        public DateTime? ModifyDate { get; set; }
    }
}
