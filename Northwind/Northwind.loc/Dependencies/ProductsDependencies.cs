using Microsoft.Extensions.DependencyInjection;
using Northwind.Application.Contracts;
using Northwind.Application.Services;
using Northwind.Infrastructure.Interfaces;
using Northwind.Infrastructure.Repositories;

namespace Northwind.loc.Dependecies
{
    public static class ProductsDependecies
    {
        public static void AddProductsDependecies(this IServiceCollection service)
        {

            service.AddScoped<IProductsService, ProductsService>();
            service.AddTransient<IProductsRepository, ProductsRepository>();


        }



    }
}
