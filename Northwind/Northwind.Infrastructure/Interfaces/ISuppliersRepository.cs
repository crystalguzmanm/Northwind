using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using System.Collections.Generic;


namespace Northwind.Infrastructure.Interfaces
{
    public  interface ISuppliersRepository :IBaseRepository<Shippers>
    {
       
            List<Suppliers> GetSuppliersBySuppliersID(int SuppliersID);
        
    }
}
