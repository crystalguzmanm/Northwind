
using Northwind.Domain.Core;

namespace Northwind.Domain.Entities
{
    public class Shippers : Person
    {
        public int ShipperID {  get; set; } 
        public string? HomePage { get; set; }  
    }
}
