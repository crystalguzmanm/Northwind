using Northwind.Domain.Entities;
using Northwind.Infrastructure.Context;
using Northwind.Infrastructure.Core;
using Northwind.Infrastructure.Interfaces;
using Northwind.Infrastructure.Models;
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
            return this.context.OrdersDetails.Where(st => !st.Deleted)
                                                        .OrderByDescending(st => st.CreationDate).ToList();

        }

        public IEnumerable<OrdersDetails> GetOrdersDetails()
        {
            throw new System.NotImplementedException();
        }

        public List<OrdersDetails> GetOrdersDetailsByOrderDetailID(int orderDetailID)
        {
            return this.context.OrdersDetails.Where(cd => cd.OrderDetailsID == orderDetailID && !cd.Deleted).ToList();
        }
        public override void Save(OrdersDetails entity)
        {
            context.OrdersDetails.Add(entity);
            context.SaveChanges();

        }
        public override void Update(OrdersDetails entity)
        {
            OrdersDetails ordersDetails = this.GetEntity(entity.OrderDetailsID);
            ordersDetails.ModifyDate = entity.ModifyDate;
            ordersDetails.UserMod = entity.UserMod;
            ordersDetails.Discount = entity.Discount;
            ordersDetails.Quantity = entity.Quantity;
            
           

            this.context.OrdersDetails.Update(ordersDetails);
            this.context.SaveChanges();

        }
        public override void Remove(OrdersDetails entity)
        {
            OrdersDetails ordersDetails = this.GetEntity(entity.OrderDetailsID);

            ordersDetails.OrderDetailsID = entity.OrderDetailsID;
            ordersDetails.Deleted = entity.Deleted;
            ordersDetails.DeletedDate = entity.DeletedDate;
            ordersDetails.UserDeleted = entity.UserDeleted;

            this.context.OrdersDetails.Update(ordersDetails);

            this.context.SaveChanges();
        }

        public List<OrdersDetailsProductsModel> GetOrdersDetailsByProductID(int productID)
        {
            return this.GetOrdersDetailsProducts().Where(cd => cd.ProductID == productID).ToList();

        }

        public List<OrdersDetailsProductsModel> GetOrdersDetailsProducts()
        {
            var ordersDetails = (from co in this.GetEntities()
                          join Prdc in this.context.Products on co.ProductID equals Prdc.ProductID
                                 where !co.Deleted
                          select new OrdersDetailsProductsModel()
                          {
                              OrderDetailsID = co.OrderDetailsID,
                              Quantity = co.Quantity,
                              Discount = co.Discount,
                              ProductID = Prdc.ProductID,
                              ProductName = Prdc.ProductName,
                              QuantityPerUnit = Prdc.QuantityPerUnit,
                              UnitsInStock = Prdc.UnitsInStock

                          }).ToList();


            return ordersDetails;
        }

        public OrdersDetailsProductsModel GetOrderDetailProduct(int productID)
        {
            return this.GetOrdersDetailsProducts().SingleOrDefault(co => co.ProductID == productID);
        }
        public List<OrdersDetails> GetOrdersDetailsByProduct(int productID)
        {
            return this.context.OrdersDetails.Where(cd => cd.ProductID == productID
                                              && !cd.Deleted).ToList();
        }
    }
}
