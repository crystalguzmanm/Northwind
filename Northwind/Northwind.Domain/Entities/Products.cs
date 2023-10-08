using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Northwind.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Domain.Entities
{
    public class Products : BaseEntity
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        public string? QuantityPerUnit { get; set; }
        public int? UnitPrice { get; set; } 
        public int? UnitsInStock { get; set; }
        public int? UnitsOnOrder { get; set; }
        public int? ReorderLevel { get; set; }
        public bool Discontinued {  get; set; }

    }
}