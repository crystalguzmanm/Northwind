using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using System.Collections.Generic;

namespace Northwind.Infrastructure.Interfaces
{
    public interface IEmployeesRepository : IBaseRepository<Employees>
    {
        List<Employees> GetEmployeesByEmployeeID(int EmployeeID);
    }
}
