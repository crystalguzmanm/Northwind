using Northwind.API.Models.Core;

namespace Northwind.API.Models.Modules.Customers
{
    public class UpdateCustomersModelcs : CustomersBaseModel
    {
        public string CustomerID { get; set; }
    }
}
