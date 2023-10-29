

using Microsoft.Extensions.DependencyInjection;
using Northwind.Application.Contracts;
using Northwind.Application.Services;
using Northwind.Infrastructure.Interfaces;
using Northwind.Infrastructure.Repositories;

namespace Northwind.loc.Dependencies
{
    public static class CustomersDependencies
    {
        public static void AddCustomersDependencies(this IServiceCollection service) 
        {
            service.AddScoped<ICustomersRepository, CustomersRepository>();
            service.AddTransient<ICustomersService, CustomersService>();
        }
    }
}
