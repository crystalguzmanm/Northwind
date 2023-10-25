using Microsoft.Extensions.DependencyInjection;
using Northwind.Application.Contracts;
using Northwind.Application.Services;
using Northwind.Infrastructure.Interfaces;
using Northwind.Domain.Repository;
using Northwind.Infrastructure.Repositories;

namespace Northwind.loc.Dependecies
{
    public static class CategoriesDependency
    {
        public static void AddCategoriesDepency(this IServiceCollection service)
        {
            IServiceCollection serviceCollection1 = service.AddScoped<ICategoriesRepository, CategoriesRepository>();
            IServiceCollection serviceCollection = service.AddTransient<CategoriesService, CategoriesService>();

        }
    }
}
