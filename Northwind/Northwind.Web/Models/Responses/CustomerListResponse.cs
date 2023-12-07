namespace Northwind.Web.Models.Responses
{
    public class CustomerListResponse
    {
        public bool success { get; set; }
        public object message { get; set; }
        public List<CustomersViewResult> data { get; set; }
    }

    public class CustomersViewResult
    {
        public int CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string ChangeUser { get; set; }
        public object ModifyDate { get; set; }
        public object ContactName { get; set; }
    }
}
