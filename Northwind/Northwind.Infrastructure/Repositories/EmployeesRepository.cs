using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using Northwind.Infrastructure.Context;
using Northwind.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using IEmployeesRepository = Northwind.Domain.Repository.IEmployeesRepository;

namespace Northwind.Infrastructure.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly NorthwindContext context;

        public bool Exists(Expression<Func<Employees, bool>> filter)
        {
            return this.context.Employees.Any(filter);
        }

        public List<Employees> GetEmployees()
        {
            return this.context.Employees.Where(ca => !ca.Deleted).ToList();
        }


        public Employees GetEmployess(int Id)
        {
            return this.context.Employees.Find(Id);
        }


        public void save(Employees employees)
        {
            this.context.Employees.Add(employees);
        }


        public void Update(Employees employees)
        {
            this.context.Update(employees);
        }
    }
}
