using Microsoft.Extensions.DependencyInjection;
using Northwind.Application.Contracts;
using Northwind.Application.Services;
using Northwind.Infrastructure.Interfaces;
using Northwind.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.loc.Dependecies
{
    public static class SuppliersDependecies
    {
        public static void AddSuppliersDependecies(this IServiceCollection service)
        {

            service.AddScoped<ISuppliersRepository, SuppliersRepository>();
            service.AddTransient<ISuppliersService, SuppliersService1>();


        }



    }
}
