namespace Northwind.Web.Models.Response
{
    public class SuppliersListResponse
    {
        public bool success { get; set; }
        public object? message { get; set; }
        public List<SuppliersViewResult> data { get; set; }
    }
    public class SuppliersViewResult
    {
        public int id  { get; set; }
        public string? companyName { get; set; }
        public string? phone { get; set; }
        public DateTime creationDate { get; set; }
        public int creationUser { get; set; }
        public object? modifyDate { get; set; }
        public object? userMod { get; set; }
        public object? userDeleted { get; set; }
        public object? deletedDate { get; set; }
        public bool deleted { get; set; }
    }
}
