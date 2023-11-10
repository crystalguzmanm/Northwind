using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Domain.Core
{
    public class Company : BaseEntity
    {
        public string? CompanyName { get; set; }

        public string? Phone { get; set; }

    }
}
