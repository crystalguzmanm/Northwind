using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Infrastructure.Context
{
    public  class CategoriesContext : DbContext
    {
        public CategoriesContext(DbContextOptions<CategoriesContext> options) : base(options)
        {

        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Employees> Employees { get; set; }

    }
}
