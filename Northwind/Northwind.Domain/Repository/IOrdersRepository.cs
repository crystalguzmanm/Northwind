using Northwind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Northwind.Domain.Repository
{
    public interface IOrdersRepository
    {
        void Save(Orders orders);

        void Update(Orders orders);
        void Remove(Orders orders);
        List<Orders> GetOrders();
        Orders GetOrders(int Id);

        bool Exists(Expression<Func<Orders, bool>> filter);
    }

}

