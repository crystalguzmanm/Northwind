using Microsoft.Extensions.DependencyInjection;
using Northwind.Application.Contracts;
using Northwind.Application.Services;
using Northwind.Infrastructure.Interfaces;
using Northwind.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.loc.Dependencies
{
    public static class  OrdersDetailsDependency
    {
        public static void AddOrdersDetailsDependecy(this IServiceCollection service)
        {
            service.AddScoped<IOrdersDetailsRepository, OrdersDetailsRepository>();
            service.AddTransient<IOrdersDetailsServices, OrdersDetailsService>();
        }
    }
}
