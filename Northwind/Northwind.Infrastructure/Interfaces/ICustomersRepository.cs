using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using System.Collections.Generic;

namespace Northwind.Infrastructure.Interfaces
{
    public interface ICustomersRepository : IBaseRepository<Customers>
    {
        IEnumerable<Customers> GetCustomers();
        List<Customers> GetCustomersByCustomerID(int CustomerID);
    }
}

