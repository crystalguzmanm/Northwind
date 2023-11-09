
using System;

namespace Northwind.Application.Dtos
{
    public abstract class DtoBase
    {
      
        public int ChangeUser {  get; set; }
        public DateTime CreationDate { get; set; }
        public int CreationUser { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
