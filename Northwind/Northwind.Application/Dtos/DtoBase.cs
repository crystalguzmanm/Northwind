
using System;

namespace Northwind.Application.Dtos
{
    public abstract class DtoBase
    {
        public int ChangeUser {  get; set; }
        public DateTime ChangeDate { get; set; }
        public int CreationUser { get; set; }
    }
}
