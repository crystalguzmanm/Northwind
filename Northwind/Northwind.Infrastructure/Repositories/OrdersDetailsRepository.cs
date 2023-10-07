using Northwind.Domain.Entities;
using Northwind.Infrastructure.Context;
//using Northwind.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Northwind.Domain.Repository;
using IOrdersDetailsRepository = Northwind.Domain.Repository.IOrdersDetailsRepository;





namespace Northwind.Infrastructure.Repositories
{
    public class OrdersDetailsRepository : IOrdersDetailsRepository
    {
        private readonly NorthwindContext context;
        public OrdersDetailsRepository(NorthwindContext context)
        {
            this.context = context;
        }

        public bool Exists(Expression<Func<OrdersDetails, bool>> filter)
        {

            return this.context.OrdersDetails.Any(filter);

        }

        public List<OrdersDetails> GetOrdersDetails()
        {
            return this.context.OrdersDetails.Where(ca => !ca.Deleted).ToList();
        }

        public OrdersDetails GetOrdesDetails(int Id)
        {

            return this.context.OrdersDetails.Find(Id);
        }

        

        public void Remove(OrdersDetails ordersDetails)
        {
            this.context.Remove(ordersDetails);
        }

        public void Save(OrdersDetails ordersDetails)
        {
            this.context.OrdersDetails.Add(ordersDetails);
        }

        public void Update(OrdersDetails ordersDetails)
        {
            this.context.Update(ordersDetails);
        }

        OrdersDetails IOrdersDetailsRepository.GetOrdersDetails(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
