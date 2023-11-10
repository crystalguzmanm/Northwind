
using System;

namespace Northwind.Application.Dtos
{
    public abstract class DtoBase
    {

       
        public DateTime CreationDate { get; set; }
        public int CreationUser { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
