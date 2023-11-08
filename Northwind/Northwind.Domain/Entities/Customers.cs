using Northwind.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Domain.Entities
{
    public class Customers : Person
    {
        [Key]
        public int CustomerID { get; set; }
        
    }
}
