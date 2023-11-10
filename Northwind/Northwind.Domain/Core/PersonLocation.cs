namespace Northwind.Domain.Core
{
    public class PersonLocation : BaseEntity
    {
        public string? City { get; set; }

        public string? Region { get; set; }

        public string? PostalCode { get; set; }

        public string? Country { get; set; }

        public string? Address { get; set; }
    }
}
