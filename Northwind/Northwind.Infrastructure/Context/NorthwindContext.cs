using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Northwind.Infrastructure.Context
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options)
        {

        }
        public DbSet<Products> Products { get; set; }
    }
}
