using Microsoft.Azure.Amqp.Framing;

namespace Northwind.Web.Models.Response
{
    public class ShippersDetailResponse
    {
        public bool success { get; set; }
        public object message { get; set; }
        public Data data { get; set; }
    }
     
}
