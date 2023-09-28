using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using System.Collections.Generic;


namespace Northwind.Infrastructure.Interfaces
{
    public interface ISuppliersRepository : IBaseRepository<Suppliers>
    {
        List<Suppliers> GetSuppliersBySuppliersID(int SuppliersID);

    }

}
