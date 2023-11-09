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
        List<OrdersEmployeesModel> GetAllOrders(); //Este llama Todos los datos GetAll
        OrdersEmployeesModel GetOrderEmployee(int Id); //Este es por ID general

        List<OrdersEmployeesModel> GetOrdersByShipperID(int shipperID);
       // List<OrdersShippersModel> GetOrdersShippers();
       // OrdersShippersModel GetOrderShipper(int ShipperID); 

        List<OrdersEmployeesModel> GetOrdersByCustomerID(string customerID);
        //List<OrdersCustomersModel> GetOrdersCustomers();
       // OrdersCustomersModel GetOrderCustomer(string CustomerID); 



    }
}
