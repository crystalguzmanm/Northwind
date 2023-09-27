using System.Collections.Generic;

namespace Northwind.Domain.Repository
{
    public interface IBaseRepository <TEntity> where TEntity : class
    {
        void Save(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        List<TEntity> GetEntities();

        TEntity GetEntity(int id);
    }
}
