namespace Northwind.Web.Models.Response
{
    public class ShippersListResponse
    {
        public bool success { get; set; }
        public object message { get; set; }
        public List<ShippersViewResult> data { get; set; }

    }

    public class ShippersViewResult
    {
        public int id { get; set; }
        public string companyName { get; set; }
        public string phone { get; set; }
        public DateTime creationDate { get; set; }
        public object modifyDate { get; set; }
        public object contactName { get; set; }
    }

   


}
