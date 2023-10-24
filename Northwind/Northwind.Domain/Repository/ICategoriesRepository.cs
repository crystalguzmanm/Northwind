using Northwind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Northwind.Domain.Repository
{
    public interface ICategoriesRepository
    {

        void Save(Categories categories);

        void Update(Categories categories);

        void Remove(Categories categories);

        List<Categories> GetCategories();

        Categories GetCategories(int Id);

        bool Exists(Expression<Func<Categories, bool>> filter);
        List<Categories> GetCategoriesByCategoriesID(int CategoriesID);
    }
}
