namespace Northwind.API.Models.Core
{
    public class OrdersBaseModel
    {
        public int CreationUser { get; set; }

        public DateTime? ModifyDate { get; set; }
        public string? CustomerID { get; set; }
        public int? EmployeeID { get; set; }
    }
}
