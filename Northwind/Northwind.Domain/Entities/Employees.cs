using Northwind.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Domain.Entities
{
    public class Employees : PersonLocation
    {
        public int EmployeeID { get; set; }

        public int LastName { get; set; }

        public string FirstName { get; set; }

        public string? Title { get; set; }

        public string? TitleOfCourtesy { get; set; }

        public DateTime? BirthDate { get; set;}

        public DateTime? HireDate { get; set; }

        public string? HomePhone { get; set; }

        public string? Extencion { get; set; }

        public byte? Photo { get; set; }

        public string? Notes { get; set; }

    }
}
