using OrderReceiver.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderReceiver.Database.Contracts
{
    public interface IDataAccess
    {
        public bool TryAdd<T, TId>(T itemToAdd) where T : class, IHasIdProperty<TId>;
        public bool TryDelete<T, TId>(TId id) where T : class, IHasIdProperty<TId>;
        public bool TryUpdate<T, TId>(TId id, T updatedItem) where T : class, IHasIdProperty<TId>;
        public bool TryGet<T, TId>(out T[] items) where T : class, IHasIdProperty<TId>;
    }
}
