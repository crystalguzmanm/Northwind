﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

//TODO agregar nuevamente repositorio de customers con sus metodos en domain.repository
namespace Northwind.Domain.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Save(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);

        List<TEntity> GetEntities();

        TEntity GetEntity(int id);

        bool Exists(Expression<Func<TEntity, bool>> filter);

        List<TEntity> FindAll(Expression<Func<TEntity, bool>> filter);
    }
}
