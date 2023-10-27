using Microsoft.Extensions.DependencyInjection;
using Northwind.Application.Contracts;
using Northwind.Application.Services;
using Northwind.Infrastructure.Interfaces;
using Northwind.Infrastructure.Repositories;

namespace Northwind.loc.Dependecies
{
    public static class CategoriesDependency
    {
        public static void AddCategoriesDepency(this IServiceCollection service)
        {
            service.AddScoped<ICategoriesRepository, CategoriesRepository>();
            service.AddTransient<CategoriesDependency, CategoriesService>();

            //IServiceCollection serviceCollection = service.AddTransient<CategoriesService, CategoriesService>();

        }
    }
}
