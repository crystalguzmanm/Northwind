using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using System.Collections.Generic;

namespace Northwind.Infrastructure.Interfaces
{
    public interface  IOrdersRepository:IBaseRepository<Orders>
    {
        List<Orders> GetOrderByOrdersID(int OrderID);
    }
}
