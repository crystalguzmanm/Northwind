
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
        public OrdersEmployeesModel GetOrderEmployee(int Id) 
        {
            return this.GetAllOrders().SingleOrDefault(co => co.OrderID == Id);
        }
        public List<Orders> GetOrdersByEmployee(int employeeID)
        {
            return this.context.Orders.Where(cd => cd.EmployeeID == employeeID
                                              && !cd.Deleted).ToList();
        }

        public List<OrdersEmployeesModel> GetOrdersByEmployeeID(int employeeID)
        {
            return this.GetAllOrders().Where(cd => cd.EmployeeID == employeeID).ToList();
        }

        public List<OrdersEmployeesModel> GetAllOrders()
        {

            var reception = (from co in this.GetEntities() 
                           join Emply in this.context.Employees on co.EmployeeID equals Emply.EmployeeID
                          where !co.Deleted
                          join Ship in this.context.Shippers on co.ShipperID equals Ship.ShipperID
                          where !co.Deleted
                          join Cstm in this.context.Customers on co.CustomerID equals Cstm.CustomerID
                          where !co.Deleted
                          select new OrdersEmployeesModel()
                           {
                               OrderID = co.OrderID,
                               ShipName = co.ShipName,
                               ShipCity = co.ShipCity,

                               EmployeeID = Emply.EmployeeID,
                               LastName = Emply.LastName,
                               FirstName = Emply.FirstName,

                              ShipperID = Ship.ShipperID,
                              CompanyName = Ship.CompanyName,
                              Phone = Ship.Phone,

                              CustomerID = Cstm.CustomerID,
                              //PhoneCstm = Cstm.Phone,
                             // CompanyNameCstm = Cstm.CompanyName,
                              Country = Cstm.Country,

                          }).ToList();


            return reception;
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

        public List<OrdersEmployeesModel> GetOrdersByShipperID(int shipperID)
        {
            return this.GetAllOrders().Where(cd => cd.ShipperID == shipperID).ToList();
        }

        public List<OrdersEmployeesModel> GetOrdersByCustomerID(string customerID) 
        {
            return this.GetAllOrders().Where(cd => cd.CustomerID == customerID).ToList();
        }

        

    }
}
