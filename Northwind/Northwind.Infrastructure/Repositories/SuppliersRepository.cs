using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using Northwind.Infrastructure.Context;
using Northwind.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ISuppliersRepository = Northwind.Domain.Repository.ISuppliersRepository;

namespace Northwind.Infrastructure.Repositories
{
    public class SuppliersRepository : ISuppliersRepository
    {
        private readonly NorthwindContext context;

        public SuppliersRepository(NorthwindContext context)
        {
            this.context = context;
        }

        public bool Exists(Expression<Func<Suppliers, bool>> filter)
        {

            return this.context.Suppliers.Any(filter);

        }

        public Suppliers GetSuppliers(int Id)
        {

            return this.context.Suppliers.Find(Id);
        }

        public List<Suppliers> GetSuppliers()
        {

            return this.context.Suppliers.Where(ca => !ca.Deleted).ToList();
        }

        public void Remove(Suppliers suppliers)
        {
            this.context.Remove(suppliers);
        }

        public void Save(Suppliers suppliers)
        {
            this.context.Suppliers.Add(suppliers);
        }

        public void Update(Suppliers suppliers)
        {
            this.context.Update(suppliers);
        }



    }
}
