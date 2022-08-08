﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderReceiver.Database
{
    public abstract class BaseContext<Context>: IDisposable
        where Context: IDisposable
    {
        protected readonly Context WorkingContext;

        protected BaseContext(Context workingContext)
        {
            WorkingContext = workingContext;
        }

        public void Dispose()
        {
            WorkingContext?.Dispose();
        }
    }
}
