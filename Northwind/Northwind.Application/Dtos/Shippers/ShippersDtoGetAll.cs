using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Dtos.Shippers
{
    public class ShippersDtoGetAll
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }

        public string? Phone { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public string? ContactName { get; set; }



    }
}