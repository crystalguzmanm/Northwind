namespace Northwind.Web.Models.Response
{
    public class OrdersListResponse
    {
        public bool success { get; set; }
        public object? message { get; set; }
        public List<OrdersViewResult> data { get; set; }
    }
    public class OrdersViewResult
    {
        public int CreationUser { get; set; }

        public DateTime? ModifyDate { get; set; }

        public string? ShipName { get; set; }
        public string? CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public int? UserMod { get; set; }
        public DateTime CreationDate { get; set; }
        public string? ShipCity { get; set; }
        public int OrderID { get; set; }
    }
}
