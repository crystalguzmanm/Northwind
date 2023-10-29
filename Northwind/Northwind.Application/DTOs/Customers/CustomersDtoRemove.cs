
namespace Northwind.Application.DTOs.Customers
{
    public class CustomersDtoRemove : CustomersDtoBase
    {
        public int ID { get; set; }
        public bool Deleted { get; set; }
    }
}
