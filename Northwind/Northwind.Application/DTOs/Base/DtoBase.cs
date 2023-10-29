using System;

namespace Northwind.Application.DTOs.Base
{
    public abstract class DtoBase
    {
        public int ChangeUser { get; set; }

        public DateTime ChangeDate { get; set; }
    }
}
