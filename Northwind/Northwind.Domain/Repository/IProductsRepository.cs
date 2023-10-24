using Northwind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Repository
{
    public interface IProductsRepository
    {
        Task Add (Products products);

        Task Update(Products products);

        Task Delete(Products products);
        Task<List<Products>> GetAll();
        Task<Products> GetById(int Id);
        Task<List<Products>> GetAllById(int Id);

        bool Exists(Expression<Func<Products, bool>> filter);
    }
}
