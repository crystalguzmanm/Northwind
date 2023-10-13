using Northwind.Domain.Entities;
using Northwind.Infrastructure.Context;
using Northwind.Infrastructure.Core;
using Northwind.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.Infrastructure.Repositories
{
    public class OrdersRepository : BaseRepository<Orders>, IOrdersRepository
    {
        private readonly NorthwindContext context;
        public OrdersRepository(NorthwindContext context) : base(context)
        {
            this.context = context;
        }
        public List<Orders> GetOrdersByDeparment(int orderID)
        {
            return this.context.Orders.Where(cd => cd.OrderID == orderID && !cd.Deleted).ToList();

        }
        public override List<Orders> GetEntities()
        {
            return base.GetEntities().Where(co => !co.Deleted).ToList();
        }
        //De aqui pa abajo con bombillito
        public IEnumerable<Orders> GetOrders()
        {
            throw new System.NotImplementedException();
        }

        public List<Orders> GetOrdersByOrderID(int OrderID)
        {
            throw new System.NotImplementedException();
        }
    }
}
