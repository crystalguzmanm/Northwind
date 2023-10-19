namespace Northwind.API.Models.Core
{
    public class SuppliersBaseModel : ModelBase
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? ContactName { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ModifyDate { get; set; }

    }
}
