
using Microsoft.Extensions.Configuration;

namespace Northwind.Application.DTOs.Customers
{
    public class CustomersDtoRemove : CustomersDtoBase
    {

        public CustomersDtoRemove(IConfiguration configuration) : base(configuration)
        {

        }

        public int CustomerID { get; set; }
        public bool Deleted { get; set; }
    }
}
