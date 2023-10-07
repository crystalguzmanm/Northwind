﻿using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using Northwind.Infrastructure.Context;
using Northwind.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

//TODO
namespace Northwind.Infrastructure.Repositories
{
    public class CustomersRepository : Domain.Repository.ICustomersRepository
    {

        private readonly NorthwindContext context;

        public CustomersRepository(NorthwindContext context)
        {
            this.context = context;
        }

        public bool Exists(Expression<Func<Customers, bool>> filter) 
        {
            return this.context.Customers.Any(filter);
        }

        public Customers GetCustomers(int id)
        {
            return this.context.Customers.Find(id);
        }

        public List<Customers> GetCustomers()
        {
            return this.context.Customers.Where(ca => !ca.Deleted).ToList();
        }
        public void Save(Customers customers)
        {
            this.context.Customers.Add(customers);
        }

        public void Update(Customers customers)
        {
            this.context.Update(customers);
        }

        public void Remove(Customers customers)
        {
            this.context.Customers.Remove(customers);
        }
    }
}

