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


        List<OrdersEmployeesModel> GetOrdersByEmployeeID(int employeeID); //TODO Llama la ID de la entidad
        List<OrdersEmployeesModel> GetOrdersEmployees(); //Este llama Todos los datos GetAll
        OrdersEmployeesModel GetOrderEmployee(int EmployeeID); //Este es por ID general

        List<OrdersShippersModel> GetOrdersByShipperID(int shipperID);//TODO Dejar este
        List<OrdersShippersModel> GetOrdersShippers();
        OrdersShippersModel GetOrderShipper(int ShipperID); 

        List<OrdersCustomersModel> GetOrdersByCustomerID(string customerID);//TODO Dejar este
        List<OrdersCustomersModel> GetOrdersCustomers();
        OrdersCustomersModel GetOrderCustomer(string CustomerID); 



    }
}
