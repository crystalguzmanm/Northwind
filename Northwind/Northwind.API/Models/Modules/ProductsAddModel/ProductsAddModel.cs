using Northwind.API.Models.Core;

namespace Northwind.API.Models.Modules.ProductsAddModel
{
    public class ProductsAddModel : ModelBase
    {
        public string ProductName { get; set; }

        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }

        public DateTime CreationDate { get; set; }

        public int CreationUser { get; set; }   
    }
}
