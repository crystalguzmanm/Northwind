using Northwind.Domain.Entities;
using Northwind.Infrastructure.Context;
// using Northwind.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Northwind.Domain.Repository;
using IProductsRepository = Northwind.Domain.Repository.IProductsRepository;

namespace Northwind.Infrastructure.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly NorthwindContext context;

        public ProductsRepository(NorthwindContext context)
        {
            this.context = context;
        }

        public bool Exists(Expression<Func<Products, bool>> filter)
        {

            return this.context.Products.Any(filter);

        }


        public Products GetProducts(int Id)
        {

            return this.context.Products.Find(Id);
        }

        public List<Products> GetProducts()
        {

            return this.context.Products.Where(ca => !ca.Deleted).ToList();
        }

        public void Remove(Products products)
        {
            this.context.Remove(products);
        }

        public void Save(Products products)
        {
            this.context.Products.Add(products);
        }

        public void Update(Products products)
        {
            this.context.Update(products);
        }

        Products IProductsRepository.GetProducts(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
