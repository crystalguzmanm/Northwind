using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Repository;
using Northwind.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

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

            public virtual TEntity GetEntity(int Id)
            {
                return this.entities.Find(Id);
            }

            public virtual void Remove(TEntity entity)
            {
                this.entities.Remove(entity);
                this.context.SaveChanges();
        }

            public virtual void Save(TEntity entity)
            {
                this.entities.Add(entity);
                this.context.SaveChanges();
        }


            public virtual void Update(TEntity entity)
            {
                this.entities.Update(entity);
                this.context.SaveChanges();
            }
        }

    }
