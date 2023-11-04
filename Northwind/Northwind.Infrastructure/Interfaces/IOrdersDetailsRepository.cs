using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using Northwind.Infrastructure.Models;
using System.Collections.Generic;

namespace Northwind.Infrastructure.Interfaces
{
    public interface IOrdersDetailsRepository : IBaseRepository<OrdersDetails>
    {
        IEnumerable<OrdersDetails> GetOrdersDetails();
        List<OrdersDetails> GetOrdersDetailsByOrderDetailID(int OrderDetailID);//Metood exlcusivo


        List<OrdersDetailsProductsModel> GetOrdersDetailsByProductID(int productID);
        List<OrdersDetailsProductsModel> GetOrdersDetailsProducts();
        OrdersDetailsProductsModel GetOrderDetailProduct(int EmployeeID); 

    }
}
