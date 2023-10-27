using Northwind.Domain.Entities;
using Northwind.Infrastructure.Context;
using Northwind.Infrastructure.Core;
using Northwind.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;



namespace Northwind.Infrastructure.Repositories
{
    public class OrdersDetailsRepository : BaseRepository<OrdersDetails>, IOrdersDetailsRepository
    {
        private readonly NorthwindContext context;
        public OrdersDetailsRepository(NorthwindContext context) : base(context)
        {
            this.context = context;
        }
        public List<OrdersDetails> GetOrdersDetailsByOrderDetailsID(int orderDetailsID)
        {
            return this.context.OrdersDetails.Where(cd => cd.OrderDetailsID == orderDetailsID && !cd.Deleted).ToList();

        }
        public override List<OrdersDetails> GetEntities()
        {
            return base.GetEntities().Where(co => !co.Deleted).ToList();
        }

        public IEnumerable<OrdersDetails> GetOrdersDetails()
        {
            throw new System.NotImplementedException();
        }

        public List<OrdersDetails> GetOrdersDetailsByOrderDetailID(int OrderDetailID)
        {
            throw new System.NotImplementedException();
        }
        public override void Save(OrdersDetails entity)
        {
            context.OrdersDetails.Add(entity);
            context.SaveChanges();

        }
        public override void Update(OrdersDetails entity)
        {
            var ordersDetailsUpdate = base.GetEntity(entity.OrderDetailsID);
            ordersDetailsUpdate.UserMod = entity.UserMod;
            ordersDetailsUpdate.ModifyDate = entity.ModifyDate;
            ordersDetailsUpdate.CreationDate = entity.CreationDate;
            ordersDetailsUpdate.CreationUser = entity.CreationUser;
            ordersDetailsUpdate.Discount = entity.Discount;

            context.OrdersDetails.Update(ordersDetailsUpdate);
            context.SaveChanges();

        }

    }
}
