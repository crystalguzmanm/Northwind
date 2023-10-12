namespace Northwind.API.Models.Modules.Shippers
{
    public class GetShippersModel
    {

        public int Id { get; set; }
        public string? CompanyName { get; set; }

        public string? Phone { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ModifyDate { get; set; }

    }
}
