using Northwind.Domain.Entities;
using Northwind.Infrastructure.Context;
using Northwind.Infrastructure.Interfaces;
using Northwind.Infrastructure.Core;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Northwind.Infrastructure.Repositories
{
    public class ProductsRepository : BaseRepository<Products>, IProductsRepository
    {
        private readonly NorthwindContext context;

        public ProductsRepository(NorthwindContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<Products> GetProducts()
        {
            throw new NotImplementedException();
        }

        public List<Products> GetProductsByProductID(int ProductID)
        {
            return this.context.Products.Where(cd => cd.ProductID == ProductID && cd.Deleted).ToList();
        }

        public override List<Products> GetEntities()
        {
            return this.context.Products.Where(ca => ca.Deleted).ToList();
        }

        public void Delete(int ProductID)
        {
            this.context.Products.Remove(GetEntity(ProductID));
        }

        //public List<Products> GetProductsByProductID(int ProductID)
        //{
            //throw new System.NotImplementedException();
        //}

        public List<Products> GetProductsBySupplierID(int SupplierID)
        {
            throw new System.NotImplementedException();
        }

        public List<Products> GetProductsByCategoryID(int CategoryID)
        {
            throw new System.NotImplementedException();
        }
    }
}
