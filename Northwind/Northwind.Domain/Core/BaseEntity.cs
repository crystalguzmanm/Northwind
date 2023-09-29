﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Domain.Core
{
    public abstract class BaseEntity
    {
        public DateTime CreationDate { get; set; }

        public bool Deleted { get; set; }

        public int CreationUser { get; set; }

        public DateTime? ModifyDate { get; set; }

        public int? UserMod { get; set; }

        public int? UserDeleted { get; set; }

        public DateTime? DeletedDate { get; set; }

    }
}
