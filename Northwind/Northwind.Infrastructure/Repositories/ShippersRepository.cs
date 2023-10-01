using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using Northwind.Infrastructure.Context;
using Northwind.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using IShippersRepository = Northwind.Domain.Repository.IShippersRepository;

namespace Northwind.Infrastructure.Repositories
{
    public class ShippersRepository : IShippersRepository
    {
        private readonly NorthwindContext context;

        public ShippersRepository(NorthwindContext context)
        {
            this.context = context;
        }

        public bool Exists(Expression<Func<Shippers, bool>> filter)
        {

            return this.context.Shippers.Any(filter);

        }

        public Shippers GetShippers(int Id)
        {

            return this.context.Shippers.Find(Id);
        }

        public List<Shippers> GetShippers()
        {

            return this.context.Shippers.Where(ca => !ca.Deleted).ToList();
        }

        public void Remove(Shippers shippers)
        {
            this.context.Remove(shippers);
        }

        public void Save(Shippers shippers)
        {
            this.context.Shippers.Add(shippers);
        }

        public void Update(Shippers shippers)
        {
            this.context.Update(shippers);
        }





    }
}
