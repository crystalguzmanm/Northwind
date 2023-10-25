using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Northwind.Application.Dtos.Categories
{
    public abstract class CategoriesDtoBase
    {

        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string? Description { get; set; }

        public byte[] Picture { get; set; }


}
}
