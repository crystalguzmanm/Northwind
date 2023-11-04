using Northwind.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Northwind.Domain.Entities
{
    public class Shippers : Company
    {
        [Key]
        public int ShipperID { get; set; }

    }
}
