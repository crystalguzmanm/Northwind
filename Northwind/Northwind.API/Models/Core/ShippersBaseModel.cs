namespace Northwind.API.Models.Core
{
    public class ShippersBaseModel : ModelBase
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }

        public string? Phone { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ModifyDate { get; set; }

      public string? ContactName { get; set; }
    }
}
