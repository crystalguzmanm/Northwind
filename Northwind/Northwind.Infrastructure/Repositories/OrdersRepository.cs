
using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using Northwind.Infrastructure.Context;
using Northwind.Infrastructure.Core;
using Northwind.Infrastructure.Interfaces;
using Northwind.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;


namespace Northwind.Infrastructure.Repositories
{
    public class OrdersRepository : BaseRepository<Orders>, IOrdersRepository
    {
        private readonly NorthwindContext context;
        public OrdersRepository(NorthwindContext context) : base(context)
        {
            this.context = context;
        }
        public OrdersEmployeesModel GetOrderEmployee(int employeeID) 
        {
            return this.GetOrdersEmployees().SingleOrDefault(co => co.EmployeeID == employeeID);
        }
        public List<Orders> GetOrdersByEmployee(int employeeID)
        {
            return this.context.Orders.Where(cd => cd.EmployeeID == employeeID
                                              && !cd.Deleted).ToList();
        }

        public List<OrdersEmployeesModel> GetOrdersByEmployeeID(int employeeID)
        {
            return this.GetOrdersEmployees().Where(cd => cd.EmployeeID == employeeID).ToList();
        }

        public List<OrdersEmployeesModel> GetOrdersEmployees()
        {

            var orders = (from co in this.GetEntities() //TODO Agregar los Joins de las otras dos entidades 
                           join Emply in this.context.Employees on co.EmployeeID equals Emply.EmployeeID
                          where !co.Deleted
                           select new OrdersEmployeesModel()
                           {
                               OrderID = co.OrderID,
                               ShipName = co.ShipName,
                               ShipCity = co.ShipCity,
                               EmployeeID = Emply.EmployeeID,
                               LastName = Emply.LastName,
                               FirstName = Emply.FirstName
                           }).ToList();


            return orders;
        }
        /*public List<Orders> GetOrdersByDeparment(int orderID)
        {
            return this.context.Orders.Where(cd => cd.OrderID == orderID && !cd.Deleted).ToList();

        }*/
        public override List<Orders> GetEntities()
        {
            return this.context.Orders.Where(st => !st.Deleted)
                                                        .OrderByDescending(st => st.CreationDate).ToList();

        }                                                
        
        //Ligh the two down
        public IEnumerable<Orders> GetOrders()
        {
            throw new System.NotImplementedException();
        }

        public List<Orders> GetOrdersByOrderID(int OrderID)
        {
            return this.context.Orders.Where(cd=>cd.OrderID ==  OrderID && !cd.Deleted).ToList();
        }
        public override void Save(Orders entity)
        {
            context.Orders.Add(entity);
            context.SaveChanges();

        }
        public override void Update(Orders entity)
        {
            Orders orders = this.GetEntity(entity.OrderID);
            orders.ModifyDate = entity.ModifyDate;
            orders.UserMod = entity.UserMod;
            orders.ShipName = entity.ShipName;
            orders.ShipCity = entity.ShipCity;

            this.context.Orders.Update(orders);
            this.context.SaveChanges();
                       
        }

        public override void Remove(Orders entity)
        {
            Orders orders = this.GetEntity(entity.OrderID);

            orders.OrderID = entity.OrderID;
            orders.Deleted = entity.Deleted;
            orders.DeletedDate = entity.DeletedDate;
            orders.UserDeleted = entity.UserDeleted;

            this.context.Orders.Update(orders);

            this.context.SaveChanges();
        }

        public List<OrdersShippersModel> GetOrdersByShipperID(int shipperID)//A
        {
            return this.GetOrdersShippers().Where(cd => cd.ShipperID == shipperID).ToList();
        }

        public List<OrdersShippersModel> GetOrdersShippers()
        {
            var orders = (from co in this.GetEntities()
                          join Shpr in this.context.Shippers on co.ShipperID equals Shpr.ShipperID
                          where !co.Deleted
                          select new OrdersShippersModel()
                          {
                              OrderID = co.OrderID,
                              ShipName = co.ShipName,
                              ShipCity = co.ShipCity,
                              ShipperID = Shpr.ShipperID,
                              CompanyName = Shpr.CompanyName,
                              Phone = Shpr.Phone

                          }).ToList();


            return orders;
        }//A

        public OrdersShippersModel GetOrderShipper(int shipperID)//A
        {
            return this.GetOrdersShippers().SingleOrDefault(co => co.ShipperID == shipperID);
        }
        public List<Orders> GetOrdersByShipper(int shipperID)
        {
            return this.context.Orders.Where(cd => cd.ShipperID == shipperID
                                              && !cd.Deleted).ToList();
        }


        public List<OrdersCustomersModel> GetOrdersByCustomerID(string customerID) //TODO ID de customer Arreglado, Go reference
        {
            return this.GetOrdersCustomers().Where(cd => cd.CustomerID == customerID).ToList();
        }

        public List<OrdersCustomersModel> GetOrdersCustomers() 
        {
            var orders = (from co in this.GetEntities()
                          join Cstm in this.context.Customers on co.CustomerID equals Cstm.CustomerID
                          where !co.Deleted
                          select new OrdersCustomersModel()
                          {
                              OrderID = co.OrderID,
                              ShipName = co.ShipName,
                              ShipCity = co.ShipCity,
                              CustomerID = Cstm.CustomerID,
                              Phone = Cstm.Phone,
                              CompanyName = Cstm.CompanyName,
                              Country = Cstm.Country

                          }).ToList();


            return orders;
        }

        public OrdersCustomersModel GetOrderCustomer(string customerID)
        {
            return this.GetOrdersCustomers().SingleOrDefault(co => co.CustomerID == customerID);
        }
        public List<Orders> GetOrdersByCustomer(string customerID)
        {
            return this.context.Orders.Where(cd => cd.CustomerID == customerID
                                              && !cd.Deleted).ToList();
        }
    }
}
