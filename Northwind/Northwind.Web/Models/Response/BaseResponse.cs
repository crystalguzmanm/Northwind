
namespace Northwind.Web.Models.Response
{
    public class BaseResponse
    {
        public bool success { get; set; }
        public object message { get; set; }
        public List<OrdersViewResult> data { get; set; }
    }
}
