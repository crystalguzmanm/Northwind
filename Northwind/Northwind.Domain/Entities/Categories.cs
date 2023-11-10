
using Northwind.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Domain.Entities
{
    public class Categories : Person
    {
        [Key]
        public int CategoryID { get; set; }

    }
}