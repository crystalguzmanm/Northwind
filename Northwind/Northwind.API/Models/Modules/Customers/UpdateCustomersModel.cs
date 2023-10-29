using Northwind.API.Models.Core;

namespace Northwind.API.Models.Modules.Customers
{
    public class UpdateCustomersModel : CustomersBaseModel
    {
        public string CustomerID { get; set; }
    }
}
