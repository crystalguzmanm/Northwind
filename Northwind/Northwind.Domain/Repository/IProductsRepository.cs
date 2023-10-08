using Northwind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Northwind.Domain.Repository
{
    public interface IProductsRepository
    {
        void Save(Products products);

        void Update(Products products);
        void Remove(Products products);
        List<Products> GetProducts();
        Products GetProducts(int Id);

        bool Exists(Expression<Func<Products, bool>> filter);
    }
}
