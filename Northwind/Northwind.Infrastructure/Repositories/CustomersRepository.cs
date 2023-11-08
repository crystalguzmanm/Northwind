using Northwind.Domain.Entities;
using Northwind.Infrastructure.Context;
using Northwind.Infrastructure.Core;
using  Northwind.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;


//TODO
namespace Northwind.Infrastructure.Repositories
{
    public class CustomersRepository : BaseRepository<Customers>, ICustomersRepository
    {
        
        private readonly NorthwindContext context;

        public CustomersRepository(NorthwindContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<Customers> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public List<Customers> GetCustomersByCustomerID(int CustomerID)
        {
            return this.context.Customers.Where(cd => cd.CustomerID == CustomerID && cd.Deleted).ToList();
        }

        public override void Save(Customers entity)
        {
            context.Customers.Add(entity);
            context.SaveChanges();

        }

        public override void Remove(Customers entity)
        {
            var CustomersToRemove = base.GetEntity(entity.CustomerID); //TODO problemas con el ID

            CustomersToRemove.CustomerID = entity.CustomerID;
            CustomersToRemove.Deleted = entity.Deleted;
            CustomersToRemove.DeletedDate = entity.DeletedDate; 
            CustomersToRemove.UserDeleted = entity.UserDeleted;

            this.context.Customers.Update(CustomersToRemove);
            this.context.SaveChanges();
        }

        public override List<Customers> GetEntities()
        {
            return this.context.Customers.Where(st => !st.Deleted)
                                               .OrderByDescending(st => st.CreationDate)
                                               .ToList();
        }
        public override void Update(Customers entity)
        {
            var customersUpdate = base.GetEntity(entity.CustomerID);
            customersUpdate.CustomerID = entity.CustomerID;
            customersUpdate.CreationUser = entity.CreationUser;
            customersUpdate.ContactName = entity.ContactName;
            customersUpdate.City = entity.City;
            customersUpdate.CreationDate = entity.CreationDate;
            customersUpdate.ModifyDate = entity.ModifyDate;
            customersUpdate.UserMod = entity.UserMod;

            context.Customers.Update(customersUpdate);
            context.SaveChanges();

        }
    }
    
}

