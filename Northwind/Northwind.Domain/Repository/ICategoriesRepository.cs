using Northwind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Northwind.Domain.Repository
{
    public interface ICategoriesRepository
    {

        void save(Categories categories);

        void Update(Categories categories);

        List<Categories> GetCategories();

        Categories GetCategories(int Id);

        bool Exists(Expression<Func<Categories, bool>> filter);

    }
}
