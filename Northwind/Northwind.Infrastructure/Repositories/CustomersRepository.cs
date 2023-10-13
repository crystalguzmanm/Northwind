using Northwind.Domain.Entities;
using Northwind.Infrastructure.Context;
using Northwind.Infrastructure.Core;
using  Northwind.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


//TODO
namespace Northwind.Infrastructure.Repositories
{
    public class CustomersRepository : BaseRepository<Customers>, ICustomersRepository
    {

        private readonly NorthwindContext context;

        public CustomersRepository(NorthwindContext context) : base(context)
        {
            this.context = context;
        }

        public List<Customers> GetCustomersByCustomerID(string CustomerID)
        {
            return this.context.Customers.Where(cd => cd.CustomerID == CustomerID && cd.Deleted).ToList();
        }

        public override List<Customers> GetEntities()
        {
            return base.GetEntities().Where(ca => !ca.Deleted).ToList();
        }

        public IEnumerable<Customers> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public List<Customers> GetCustomersByCustomerID(int CustomerID)
        {
            throw new NotImplementedException();
        }
    }
    
}

