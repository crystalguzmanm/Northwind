using Microsoft.Extensions.Configuration;
using Northwind.Application.DTOs.Base;
using Northwind.Application.Exceptions;

namespace Northwind.Application.DTOs.Customers
{
    public abstract class CustomersDtoBase : DtoBase
    {
        private string? companyName;
        private string? contactName;
        private string? phone;
        private readonly IConfiguration configuration;

        public CustomersDtoBase(IConfiguration configuration)
        {
             this.configuration = configuration;
        }

        public string? CompanyName 
        { 
            get { return this.CompanyName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new CustomerServiceException("el nombre de la compañia es requerido ");
                }
                this.CompanyName = value;
            }
        }

        public string? ContactName { get; set;}

        public string? Phone { get; set;}
    }
}
