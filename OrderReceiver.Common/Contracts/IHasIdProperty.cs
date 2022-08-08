﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderReceiver.Common.Contracts
{
    public interface IHasIdProperty<T>
    {
        public T Id { get; set; }
    }
}
