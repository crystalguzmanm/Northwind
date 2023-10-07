using Northwind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Northwind.Domain.Repository
{
    public interface ICustomersRepository
    {
        void Save(Customers customers);

        void Update(Customers customers);

        void Remove(Customers customers);

        List<Customers> GetCustomers();

        Customers GetCustomers(int Id);

        bool Exists(Expression<Func<Customers, bool>> filter);
    }
}