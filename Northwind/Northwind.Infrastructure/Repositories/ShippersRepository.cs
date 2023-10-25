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

       // public override List<Shippers> GetEntities()
      ///  {
           /// return base.GetEntities().Where(co => !co.Deleted).ToList();
        //}

        List<Shippers> IShippersRepository.GetShippersByShippersID(int ShippersID)
        {
            return this.context.Shippers.Where(cd => cd.ShipperID == ShippersID && !cd.Deleted).ToList();
        }
        public override void Save(Shippers entity)
        {
            context.Shippers.Add(entity);
            context.SaveChanges();  
            
        }

        public override void Update(Shippers entity)
        {
            var shippersUpdate = base.GetEntity(entity.ShipperID);
            shippersUpdate.CompanyName = entity.CompanyName;
            shippersUpdate.Phone=entity.Phone;
            shippersUpdate.CreationDate = entity.CreationDate;
            shippersUpdate.CreationUser = entity.CreationUser;
            shippersUpdate.UserMod = entity.UserMod;  

            context.Shippers.Update(shippersUpdate);  
            context.SaveChanges();
        }

        public override void Remove(Shippers entity)
        {
            var shippersToRemove =  base.GetEntity(entity.ShipperID);

            shippersToRemove.ShipperID = entity.ShipperID;
            shippersToRemove.Deleted= entity.Deleted;
            shippersToRemove.UserDeleted= entity.UserDeleted;
            shippersToRemove.DeletedDate = entity.DeletedDate;
            
            this.context.Shippers.Update(shippersToRemove);
            this.context.SaveChanges();

        }

        public override List <Shippers> GetEntities()
        {
           return this.context.Shippers.Where(sh => !sh.Deleted).OrderByDescending(sh => sh.CreationDate).ToList();
  
        }
  
    
    }


}
