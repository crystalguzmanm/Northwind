using Northwind.Domain.Core;

namespace Northwind.Domain.Entities
{
    public class Customers : Person
    {
        public int CustomerID { get; set; }
    }
}
