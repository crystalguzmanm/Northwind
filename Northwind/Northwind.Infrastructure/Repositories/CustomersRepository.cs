using Northwind.Domain.Entities;
using Northwind.Infrastructure.Interfaces;
using System.Collections.Generic;

namespace Northwind.Infrastructure.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        public void Delete(Customers entity)
        {
            throw new System.NotImplementedException();
        }

        public List<Customers> GetCustomersByCustomerID(int CustomerID)
        {
            throw new System.NotImplementedException();
        }

        public List<Customers> GetEntities()
        {
            throw new System.NotImplementedException();
        }

        public Customers GetEntity(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Save(Customers entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Customers entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
