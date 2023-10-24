using Northwind.Domain.Entities;
using Northwind.Infrastructure.Context;
using Northwind.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Northwind.Domain.Repository;
using IProductsRepository = Northwind.Domain.Repository.IProductsRepository;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Northwind.Infrastructure.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly NorthwindContext _context;

        public ProductsRepository(NorthwindContext context)
        {
            _context = context;
        }

        public bool Exists(Expression<Func<Products, bool>> filter)
        {

            return _context.Products.Any(filter);
        }


        public async Task<Products> GetById(int Id)
        {
            
            return await _context.Set<Products>().FirstOrDefaultAsync(product => product.ProductID == Id);
            
        }

        public async Task<List<Products>> GetAll()
        {

            return await _context.Set<Products>().ToListAsync();
            //var productList = this.context.Products.Where(ca => !ca.Deleted).ToList();
            //return productList;

        }

        public async Task Delete(Products products)
        {
             _context.Set<Products>().Remove(products);
             await _context.SaveChangesAsync();
        }

        public async Task Add(Products products)
        {
            _context.Set<Products>().Add(products);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Products products)
        {
            _context.Set<Products>().Update(products);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Products>>GetAllById(int Id)
        {
            return await _context.Set<Products>().Where(product => product.ProductID == Id).ToListAsync();
        }
    }
}
