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
    public class SuppliersRepository : BaseRepository<Suppliers>,ISuppliersRepository
    {
        private readonly NorthwindContext context;

        public SuppliersRepository(NorthwindContext context) : base(context)
        {
            this.context = context;
        }
        public List<Suppliers> GetSuppliersBySuppliersId(int suppliersId)
        {
            return this.context.Suppliers.Where(cd => cd.SupplierID == suppliersId && !cd.Deleted).ToList();
        }

        public override List<Suppliers> GetEntities()
        {
            return base.GetEntities().Where(co => !co.Deleted).ToList();
        }

        List<Suppliers> ISuppliersRepository.GetSuppliersBySuppliersID(int SuppliersID)
        {
            throw new NotImplementedException();
        }
    }
}
