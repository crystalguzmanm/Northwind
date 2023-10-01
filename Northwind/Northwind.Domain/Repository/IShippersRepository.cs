using Northwind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Northwind.Domain.Repository
{
    public interface IShippersRepository
    {
        void Save(Shippers shippers);

        void Update(Shippers shippers);
        void Remove(Shippers shippers);
        List<Shippers> GetShippers();
        Shippers GetShippers(int Id);

        bool Exists(Expression<Func<Shippers, bool>> filter);
    }
}
