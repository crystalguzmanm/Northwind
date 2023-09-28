using Northwind.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Domain.Entities
{
    public class Categories : BaseEntity
    {

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string? Description { get; set; }

        public byte[] Picture { get; set; }

    }
}
