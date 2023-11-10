
using Northwind.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Domain.Entities
{
    public class Suppliers : Person
    {
        [Key]
        public int SupplierID { get; set; }

    }
}