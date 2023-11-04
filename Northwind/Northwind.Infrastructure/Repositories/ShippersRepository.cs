using Northwind.Domain.Entities;
using Northwind.Infrastructure.Context;
using Northwind.Infrastructure.Core;
using Northwind.Infrastructure.Interfaces;


namespace Northwind.Infrastructure.Repositories
{
    public class ShippersRepository : BaseRepository<Shippers>, IShippersRepository
    {
        public ShippersRepository(NorthwindContext context) : base(context)
        {
        
        }
    }
}
