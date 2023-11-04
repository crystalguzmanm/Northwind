using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Northwind.Domain.Entities;

namespace Northwind.Infrastructure.Context
{
    public class NorthwindContext : DbContext
    {
        
            public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options)
            {

            }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrdersDetails> OrdersDetails { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Shippers> Shippers { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}
