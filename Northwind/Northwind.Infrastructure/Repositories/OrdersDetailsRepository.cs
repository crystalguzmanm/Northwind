using Northwind.Domain.Entities;
using Northwind.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Infrastructure.Repositories
{
    public class OrdersDetailsRepository : IOrdersDetailsRepository
    {
        public List<OrdersDetails> GetOrdersDetailsByOrdersID(int OrdersID)
        {
            throw new NotImplementedException();
        }
    }
}
