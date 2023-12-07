namespace Northwind.Web.Models.Response
{
    public class ProductsListResponse
    {
        public bool success { get; set; }
        public object? message { get; set; }
        public List<ProductsViewResult>? data { get; set; }

    }

    public class ProductsViewResult
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }

    }




}