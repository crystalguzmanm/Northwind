using Northwind.Domain.Entities;
using Northwind.Infrastructure.Context;
using Northwind.Infrastructure.Core;
using Northwind.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Infrastructure.Repositories
{
    public class CustomersRepository : BaseRepository<Customers>, ICustomersRepository
    {
        public CustomersRepository(NorthwindContext context) : base(context)
        {

        }
    }
}
