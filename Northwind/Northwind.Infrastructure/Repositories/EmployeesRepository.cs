using Northwind.Domain.Entities;
using Northwind.Infrastructure.Core;
using Northwind.Infrastructure.Context;
using Northwind.Infrastructure.Interfaces;


namespace Northwind.Infrastructure.Repositories
{
    public class EmployeesRepository : BaseRepository<Employees>, IEmployeesRepository
    {
        public EmployeesRepository(NorthwindContext context) : base(context)
        {
        
        }
    }
}
