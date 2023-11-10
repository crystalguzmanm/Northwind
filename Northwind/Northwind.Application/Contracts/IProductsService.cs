using Northwind.Application.Core;
using Northwind.Application.Dtos.Products;

namespace Northwind.Application.Contracts
{
    public interface IProductsService : IBaseServices<ProductsDtoAdd, ProductsDtoUpdate, ProductsDtoRemove>
    {
        object GetProductsByProductID(int productsID);
    }
}