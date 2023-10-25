using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using Northwind.Infrastructure.Context;
using Northwind.Infrastructure.Interfaces;
using School.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ICategoriesRepository = Northwind.Domain.Repository.ICategoriesRepository;
using IEmployeesRepository = Northwind.Infrastructure.Interfaces.IEmployeesRepository;

namespace Northwind.Infrastructure.Repositories
{
    public class EmployeesRepository : BaseRepository<Employees>, IEmployeesRepository
    {
        private readonly NorthwindContext context;

        public EmployeesRepository(NorthwindContext context) : base(context)
        {
            this.context = context;
        }

        public override List<Employees> GetEntities()
        {
            return base.GetEntities().Where(co => !co.Deleted).ToList();
        }

        List<Employees> IEmployeesRepository.GetEmployeesByEmployeeID(int EmployeesID)
        {
            return this.context.Employees.Where(cd => cd.EmployeeID == EmployeesID && !cd.Deleted).ToList();
        }
        public override void Save(Employees entity)
        {
            context.Employees.Add(entity);
            context.SaveChanges();

        }

        public override void Update(Employees entity)
        {
            var EmployeesUpdate = base.GetEntity(entity.EmployeeID);
            EmployeesUpdate.EmployeeID = entity.EmployeeID;
            EmployeesUpdate.City = entity.City;
            EmployeesUpdate.PostalCode = entity.PostalCode;
            EmployeesUpdate.Country = entity.Country;
            EmployeesUpdate.Address = entity.Address;

            context.SaveChanges();
        }

    /*    public List<Employees> GetEmployees()
        {
            return base.GetEntities().Where(co => !co.Deleted).ToList();
        }
    */

        public Employees GetEmployees(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Employees> GetEmployeesByEmployeeID(int EmployeeID)
        {
            throw new NotImplementedException();
        }
    }
}