using Northwind.Domain.Entities;
using Northwind.Domain.Repository;
using Northwind.Infrastructure.Context;
using Northwind.Infrastructure.Interfaces;
using School.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ICategoriesRepository = Northwind.Domain.Repository.ICategoriesRepository;

namespace Northwind.Infrastructure.Repositories
{
    public class CategoriesRepository : BaseRepository<Categories>, ICategoriesRepository
    {
        private readonly NorthwindContext context;

        public CategoriesRepository(NorthwindContext context) : base(context)
        {
            this.context = context;
        }

        public override List<Categories> GetEntities()
        {
            return base.GetEntities().Where(co => !co.Deleted).ToList();
        }

        List<Categories> ICategoriesRepository.GetCategoriesByCategoriesID(int CategoriesID)
        {
            return this.context.Categories.Where(cd => cd.CategoryId == CategoriesID && !cd.Deleted).ToList();
        }
        public override void Save(Categories entity)
        {
            context.Categories.Add(entity);
            context.SaveChanges();

        }

        public override void Update(Categories entity)
        {
            var CategoriesUpdate = base.GetEntity(entity.CategoryId);
            CategoriesUpdate.CategoryName = entity.CategoryName;
            CategoriesUpdate.Description = entity.Description;
            CategoriesUpdate.Picture = entity.Picture;
            context.SaveChanges();
        }

        public List<Categories> GetCategories()
        {
            return base.GetEntities().Where(co => !co.Deleted).ToList();
        }

        public Categories GetCategories(int Id)
        {
            throw new NotImplementedException();
        }
    }
}