using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using System.Collections.Generic;

namespace Northwind.Infrastructure.Interfaces
{
    public interface IShippersRepository : IBaseRepository<Shippers>
    {
        List<Shippers> GetShippersByShippersID(int ShippersID);

    }
}
