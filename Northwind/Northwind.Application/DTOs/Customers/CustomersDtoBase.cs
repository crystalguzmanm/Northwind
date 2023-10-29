using Northwind.Application.DTOs.Base;

namespace Northwind.Application.DTOs.Customers
{
    public class CustomersDtoBase : DtoBase
    {
        public string? CompanyName { get; set; }

        public string? ContactName { get; set;}

        public string? Phone { get; set;}
    }
}
