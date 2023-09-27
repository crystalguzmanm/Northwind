using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using System.Collections.Generic;

namespace Northwind.Infrastructure.Interfaces
{
    public class IShippersRepository : IBaseRepository<Shippers>
    {
        public void Delete(Shippers entity)
        {
            throw new System.NotImplementedException();
        }

        public List<Shippers> GetEntities()
        {
            throw new System.NotImplementedException();
        }

        public Shippers GetEntity(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Save(Shippers entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Shippers entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
