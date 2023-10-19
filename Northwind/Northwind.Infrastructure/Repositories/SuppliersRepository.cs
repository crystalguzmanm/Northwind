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
    public class SuppliersRepository : BaseRepository<Suppliers>, ISuppliersRepository
    {
        private readonly NorthwindContext context;

        public SuppliersRepository(NorthwindContext context) : base(context)
        {
            this.context = context;
        }
       

        public override List<Suppliers> GetEntities()
        {
            return base.GetEntities().Where(co => !co.Deleted).ToList();
        }

        List<Suppliers> ISuppliersRepository.GetSuppliersBySuppliersID(int SuppliersID)
        {
            return this.context.Suppliers.Where(cd => cd.SupplierID == SuppliersID && !cd.Deleted).ToList();
        }

        public override void Save(Suppliers entity)
        {
            context.Suppliers.Add(entity);
            context.SaveChanges();

        }

        public override void Update(Suppliers entity)
        {
            var suppliersUpdate = base.GetEntity(entity.SupplierID);
            suppliersUpdate.CompanyName = entity.CompanyName;
            suppliersUpdate.Phone = entity.Phone;
            suppliersUpdate.CreationDate = entity.CreationDate;
            suppliersUpdate.CreationUser = entity.CreationUser;
            suppliersUpdate.UserMod = entity.UserMod;

            context.Suppliers.Update(suppliersUpdate);
            context.SaveChanges();
        }


    }
}