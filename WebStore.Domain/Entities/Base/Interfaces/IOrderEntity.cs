﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Domain.Entities.Base.Interface
{
    public interface IOrderedEntity : IEntity
    {
        int Order { get; set; }
    }
}
