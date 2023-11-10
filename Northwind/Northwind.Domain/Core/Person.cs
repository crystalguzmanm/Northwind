namespace Northwind.Domain.Core
{
    public class Person : PersonLocation
    {
        public string? CompanyName { get; set; }
        public string? ContactName { get; set; }

        public string? ContactTitle { get; set; }

        public string? Phone { get; set; }

        public string? Fax { get; set; }

    }
}