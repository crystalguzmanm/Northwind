using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using System.Collections.Generic;

namespace Northwind.Infrastructure.Interfaces
{
    public interface IOrdersDetailsRepository
    {
        IEnumerable<OrdersDetails> GetOrdersDetails();
        List<OrdersDetails> GetOrdersDetailsByOrdersID(int OrdersDetailsID);
    }
}
