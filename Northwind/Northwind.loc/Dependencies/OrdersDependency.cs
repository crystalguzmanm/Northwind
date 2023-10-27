using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Application.Contracts;
using Northwind.Application.Services;
using Northwind.Infrastructure.Interfaces;
using Northwind.Infrastructure.Repositories;

namespace Northwind.loc.Dependencies
{
    public static class OrdersDependency
    {
        public static void AddOrdersDependecy(this IServiceCollection service)
        {
            service.AddScoped<IOrdersRepository, OrdersRepository>();
            service.AddTransient<IOrdersServices, OrdersService>();
        }
    }
}
