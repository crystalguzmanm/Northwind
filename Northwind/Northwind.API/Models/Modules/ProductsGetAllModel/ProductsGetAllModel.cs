using Northwind.API.Models.Core;

namespace Northwind.API.Models.Modules.ProductsGetAllModel
{
    public class ProductsGetAllModel : ProductsBaseModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; internal set; }
        public string QuantityPerUnit { get; internal set; }
        public decimal? UnitPrice { get; internal set; }
        public short? UnitsInStock { get; internal set; }
        public short? UnitsOnOrder { get; internal set; }
        public short? ReorderLevel { get; internal set; }
    }
}
