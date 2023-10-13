using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using System.Collections.Generic;

namespace Northwind.Infrastructure.Interfaces
{
    public interface IOrdersDetailsRepository : IBaseRepository<OrdersDetails>
    {
        IEnumerable<OrdersDetails> GetOrdersDetails();
        List<OrdersDetails> GetOrdersDetailsByOrderDetailID(int OrderDetailID);//Metood exlcusivo
    }
}
