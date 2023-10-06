using Northwind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Northwind.Domain.Repository
{
    public interface IOrdersDetailsRepository
    {
        void Save(OrdersDetails ordersDetails);
        void Update(OrdersDetails ordersDetails);
        void Remove(OrdersDetails ordersDetails);
        List<OrdersDetails> GetOrdersDetails();
        OrdersDetails GetOrdersDetails(int Id);

        bool Exists(Expression<Func<OrdersDetails, bool>> filter);
    }
}
