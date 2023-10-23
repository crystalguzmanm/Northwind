

using Microsoft.Extensions.DependencyInjection;
using Northwind.Application.Contracts;
using Northwind.Application.Services;
using Northwind.Infrastructure.Interfaces;
using Northwind.Infrastructure.Repositories;

namespace Northwind.loc.Dependecies
{
    public static  class ShippersDependency
    {
        public static void AddShippersDepency(this IServiceCollection service)
        {
            service.AddScoped<IShippersRepository, ShippersRepository>();
            service.AddTransient<IShippersService, ShippersService>();

        }
    }
}
