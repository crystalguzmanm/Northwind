using Microsoft.Azure.Amqp.Framing;
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
    public class ShippersRepository : BaseRepository<Shippers>,IShippersRepository
    {
        private readonly NorthwindContext context;

        public ShippersRepository(NorthwindContext context) : base(context)
        {
            this.context = context;
        }
        public List<Shippers> GetShippersByShipperId(int shippersId)
        {
            return this.context.Shippers.Where(cd => cd.ShipperID == shippersId && !cd.Deleted).ToList();
        }

        public override List<Shippers> GetEntities()
        {
            return base.GetEntities().Where(co => !co.Deleted).ToList();
        }

        List<Shippers> IShippersRepository.GetShippersByShippersID(int ShippersID)
        {
            throw new NotImplementedException();
        }
    }
}
