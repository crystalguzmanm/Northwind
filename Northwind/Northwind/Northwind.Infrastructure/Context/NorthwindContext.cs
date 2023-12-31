﻿using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Northwind.Infrastructure.Context
{
    public class NorthwindContext : DbContext
    {
        private readonly object entities;

        public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options)
        {

        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }
}
