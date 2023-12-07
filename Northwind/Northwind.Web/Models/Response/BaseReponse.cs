using Microsoft.Azure.Amqp.Framing;

namespace Northwind.Web.Models.Response
{
    public class BaseReponse
    {
        public bool success { get; set; }
        public object? message { get; set; }
        public Data? data { get; set; }
    }
}