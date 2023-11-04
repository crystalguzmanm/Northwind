using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using Northwind.Infrastructure.Models;
using System.Collections.Generic;

namespace Northwind.Infrastructure.Interfaces
{
    public interface IOrdersRepository : IBaseRepository<Orders>
    {
        IEnumerable<Orders> GetOrders();
        List<Orders> GetOrdersByOrderID(int OrderID);//Metood exlcusivo


        List<OrdersEmployeesModel> GetOrdersByEmployeeID(int employeeID);
        List<OrdersEmployeesModel> GetOrdersEmployees();
        OrdersEmployeesModel GetOrderEmployee(int EmployeeID); //TODO El profe tiene Id aqui


        List<OrdersShippersModel> GetOrdersByShipperID(int shipperID);
        List<OrdersShippersModel> GetOrdersShippers();
        OrdersShippersModel GetOrderShipper(int ShipperID); //TODO El profe tiene Id aqui

        List<OrdersCustomersModel> GetOrdersByCustomerID(string customerID);
        List<OrdersCustomersModel> GetOrdersCustomers();
        OrdersCustomersModel GetOrderCustomer(string CustomerID); //TODO El profe tiene Id aqui



    }
}
