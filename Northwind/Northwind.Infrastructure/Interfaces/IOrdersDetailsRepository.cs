using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using System.Collections.Generic;

namespace Northwind.Infrastructure.Interfaces
{
    public interface IOrdersDetailsRepository
    {
        List<OrdersDetails> GetOrdersDetailsByOrdersID(int OrdersID);
    }
}
