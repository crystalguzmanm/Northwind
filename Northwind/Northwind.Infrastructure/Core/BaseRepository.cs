using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Repository;
using Northwind.Infrastructure.Context;
using System.Linq;
using System;
using System.Linq.Expressions;
using System.Collections.Generic;


namespace Northwind.Infrastructure.Core
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly NorthwindContext context;

        private DbSet<TEntity> entities;

        public BaseRepository(NorthwindContext context)
        {
            this.context = context;
            this.entities = context.Set<TEntity>();
        }
       
        public virtual bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            return this.entities.Any(filter);
        }
        public virtual List<TEntity> FindAll(Expression<Func<TEntity, bool>> filter)
        {
            return this.entities.Where(filter).ToList();
        }

        public virtual List<TEntity> GetEntities()
        {
            return this.entities.ToList();
        }

        public virtual TEntity GetEntity(int id)
        {
            return this.entities.Find(id);
        }

        public virtual void Remove(TEntity entity)
        {
            this.entities.Remove(entity);   
        }

        public virtual void Save(TEntity entity)
        {
            this.entities.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            this.entities.Update(entity);
        }
    }
}
