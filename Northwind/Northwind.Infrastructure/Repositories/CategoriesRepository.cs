using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using Northwind.Infrastructure.Context;
using Northwind.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ICategoriesRepository = Northwind.Domain.Repository.ICategoriesRepository;

namespace Northwind.Infrastructure.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly NorthwindContext context;

        public CategoriesRepository(NorthwindContext context)
        {
            this.context = context;
        }


        public bool Exists(Expression<Func<Categories, bool>> filter)
        {
            return this.context.Categories.Any(filter);
        }

        public Categories GetCategories(int Id)
        {
            return this.context.Categories.Find(Id);

        }

        public List<Categories> GetCategories()
        {
            return this.context.Categories.Where(ca => !ca.Deleted).ToList();
        }

        public void Remove(Categories categories)
        {
            this.context.Categories.Remove(categories);
        }

        public void Save(Categories categories)
        {
            this.context.Categories.Add(categories);
        }

        public void Update(Categories categories)
        {
            this.context.Update(categories);
        }
    }
}
