using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using System.Collections.Generic;

namespace Northwind.Infrastructure.Interfaces
{
    public interface IProductsRepository : IBaseRepository<Products>
    {
        //IEnumerable<Products> GetProducts();
        List<Products> GetProductsByProductID(int ProductID);
        List<Products> GetProductsBySupplierID(int SupplierID);
        List<Products> GetProductsByCategoryID(int CategoryID);

    }
}

