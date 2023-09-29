using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using System.Collections.Generic;

namespace Northwind.Infrastructure.Interfaces
{
    public interface ICategoriesRepository : IBaseRepository<Categories>
    {
        List<Categories> GetCategoriesByCategoriesID(int categoryID);
    }
}
