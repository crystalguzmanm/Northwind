
using Northwind.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Domain.Entities
{
    public class Shippers : Company
    {
        [Key]
        public int ShipperID {  get; set; }
      
    }
}
