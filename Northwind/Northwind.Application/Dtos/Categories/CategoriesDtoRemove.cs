using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Application.Dtos.Categories
{
    public class CategoriesDtoRemove : DtoBase
    {
        public int CategoryID { get; set; }
        public bool Deleted { get; set; }

    }
}
