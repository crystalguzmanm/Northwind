using Northwind.API.Models.Core;

namespace Northwind.API.Models.Modules.ProductsUpdateModel
{
    public class ProductsUpdateModel : ProductsBaseModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
    }
}
