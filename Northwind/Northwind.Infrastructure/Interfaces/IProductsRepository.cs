using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Infrastructure.Interfaces
{
    public interface IProductsRepository : IBaseRepository<Products>
    {

    }
}
