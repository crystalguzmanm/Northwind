using Northwind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Northwind.Domain.Repository
{
    public interface IEmployeesRepository
    {
        void save(Employees employees);

        void Update(Employees employees);

        List<Employees> GetEmployees();

        Employees GetEmployess(int Id);

        bool Exists(Expression<Func<Employees, bool>> filter);
    }
}
