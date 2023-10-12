using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Northwind.Domain.Entities;

namespace Northwind.Infrastructure.Context
{
    public  class NorthwindContext: DbContext
    {
        private readonly object entities;

        public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options)
        {

        }

        public DbSet<Shippers> Shippers { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
    }

}
