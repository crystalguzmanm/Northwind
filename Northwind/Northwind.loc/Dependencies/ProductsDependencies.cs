using Microsoft.Extensions.DependencyInjection;

namespace Northwind.loc.Dependecies
{
    public static class SuppliersDependecies
    {
        public static void AddProductsDependecies(this IServiceCollection service)
        {

            service.AddScoped<IProductsService, ProductsService>();
            service.AddTransient<IProductsRepository, ProductsRepository>();


        }



    }
}
