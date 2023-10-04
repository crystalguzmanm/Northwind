using Northwind.Domain.Entities;
using Northwind.Infrastructure.Context;
using Northwind.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Northwind.Domain.Repository;
using IOrdersRepository = Northwind.Domain.Repository.IOrdersRepository;

namespace Northwind.Infrastructure.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {

        private readonly NorthwindContext context;

        public OrdersRepository(NorthwindContext context)
        {
            this.context = context;
        }

        public bool Exists(Expression<Func<Orders, bool>> filter)
        {

            return this.context.Orders.Any(filter);

        }


        public Orders GetOrdes(int Id)
        {

            return this.context.Orders.Find(Id);
        }

        public List<Orders> GetOrders()
        {

            return this.context.Orders.Where(ca => !ca.Deleted).ToList();
        }

        public void Remove(Orders orders)
        {
            this.context.Remove(orders);
        }

        public void Save(Orders orders)
        {
            this.context.Orders.Add(orders);
        }

        public void Update(Orders orders)
        {
            this.context.Update(orders);
        }

        Orders IOrdersRepository.GetOrders(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
