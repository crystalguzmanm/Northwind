using Northwind.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace Northwind.Domain.Entities
{
    public class Categories : BaseEntity
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string? Description { get; set; }

        public byte[] Picture { get; set; }

    }
}
