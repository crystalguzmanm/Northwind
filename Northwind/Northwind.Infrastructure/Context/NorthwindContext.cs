using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Entities;

namespace Northwind.Infrastructure.Context
{
    internal class NorthwindContext : DbContext
    {
        
            public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options)
            {

            }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrdersDetails> OrdersDetails { get; set; }

    }
}
