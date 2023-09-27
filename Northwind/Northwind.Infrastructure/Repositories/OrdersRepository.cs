using Northwind.Domain.Entities;
using Northwind.Infrastructure.Interfaces;
using System.Collections.Generic;

namespace Northwind.Infrastructure.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        
        public void Delete(Orders entity)
        {
            throw new System.NotImplementedException();
        }

        public List<Orders> GetEntities()
        {
            throw new System.NotImplementedException();
        }

        public Orders GetEntity(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Orders> GetOrderByOrdersID(int OrderID)
        {
            throw new System.NotImplementedException();
        }

        public void Save(Orders entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Orders entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
