using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrderReceiver.Common.Contracts;
using OrderReceiver.Common.Models.Database;
using OrderReceiver.Database.Contracts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace OrderReceiver.Database
{
    public class DataAccess: IDataAccess
    {
        private readonly DbContextOptions _dbOptions;
        private ILogger _logger;

        public DataAccess(DbContextOptions options, ILogger logger)
        {
            _dbOptions = options;
            _logger = logger;
        }

        public bool TryAdd<T, TId>(T itemToAdd) where T : class, IHasIdProperty<TId>
        {
            using (var crud = new BasicCRUD<T, TId>(new OrderContext(_dbOptions), _logger))
            {
                if (!crud.TryAdd(itemToAdd))
                {
                    return false;
                }
                return true;
            }
        }

        public bool TryDelete<T, TId>(TId id) where T : class, IHasIdProperty<TId>
        {
            using (var crud = new BasicCRUD<T, TId>(new OrderContext(_dbOptions), _logger))
            {
                if (!crud.TryDelete(id))
                {
                    return false;
                }
                return true;
            }
        }

        public bool TryUpdate<T, TId>(TId id, T updatedItem) where T : class, IHasIdProperty<TId>
        {
            using (var crud = new BasicCRUD<T, TId>(new OrderContext(_dbOptions), _logger))
            {
                if (!crud.TryUpdate(id, updatedItem))
                {
                    return false;
                }
                return true;
            }
        }

        public bool TryGet<T, TId>(out T[] items) where T : class, IHasIdProperty<TId>
        {
            using (var crud = new BasicCRUD<T, TId>(new OrderContext(_dbOptions), _logger))
            {
                if (!crud.TryGet(out IQueryable<T> queryItems))
                {
                    items = null;
                    return false;
                }
                items = queryItems.ToArray();
                return true;
            }
        }
    }
}
