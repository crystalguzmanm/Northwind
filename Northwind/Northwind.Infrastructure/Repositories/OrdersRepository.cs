
using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using Northwind.Infrastructure.Context;
using Northwind.Infrastructure.Core;
using Northwind.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Northwind.Infrastructure.Repositories
{
    public class OrdersRepository : BaseRepository<Orders>, IOrdersRepository
    {
        private readonly NorthwindContext context;
        public OrdersRepository(NorthwindContext context) : base(context)
        {
            this.context = context;
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
            var ordersUpdate = base.GetEntity(entity.OrderID);
            ordersUpdate.ShipName = entity.ShipName;
            ordersUpdate.UserMod = entity.UserMod;
            ordersUpdate.ModifyDate = entity.ModifyDate;
            ordersUpdate.CreationDate = entity.CreationDate;
            ordersUpdate.CreationUser = entity.CreationUser;
            ordersUpdate.OrderID = entity.OrderID;

            context.Orders.Update(ordersUpdate);
            context.SaveChanges();
                       
        }

        public override void Remove(Orders entity)
        {
            var ordersToRemove = base.GetEntity(entity.OrderID);

            ordersToRemove.OrderID = entity.OrderID;
            ordersToRemove.Deleted = entity.Deleted;
            ordersToRemove.UserDeleted = entity.UserDeleted;
            ordersToRemove.DeletedDate = entity.DeletedDate;
            //ordersToRemove.Id = entity.Id;//TODO

            this.context.Orders.Update(ordersToRemove);
            this.context.SaveChanges();
        }

    }
}
