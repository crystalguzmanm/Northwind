using Northwind.API.Models.Core;

namespace Northwind.API.Models.Modules.Customers
   
{
    public class AddCustomersModel : CustomersBaseModel
    {
        public string CustomerID { get; set; }
    }
}
