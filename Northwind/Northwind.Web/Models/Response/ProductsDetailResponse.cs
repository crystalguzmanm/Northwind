
namespace Northwind.Web.Models.Response
{
    public class ProductsDetailResponse
    {
        public bool success { get; set; }
        public object? message { get; set; }
        public ProductsViewResult? data { get; set; }
    }

}