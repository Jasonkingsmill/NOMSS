﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public interface IOrderRepository
    {
        Order GetById(int id);
    }
}
