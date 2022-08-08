using Microsoft.EntityFrameworkCore;
using AutoMapper;
using OrderReceiver.Database.Contracts;
using OrderReceiver.Database;
using Microsoft.Extensions.Logging.Debug;
using NLog.Extensions.Logging;
using NLog.Fluent;
using OrderReceiver.Services;

namespace OrderReceiver
{
    public static class DI
    {
        public static void Setup(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient<DbContextOptions>(sp => new DbContextOptionsBuilder().UseSqlite("Data Source=OrderReceiver.db").Options);
            services.AddSingleton<ILogger>(sp => sp.GetService<ILoggerFactory>().CreateLogger("NLog"));
            services.AddSingleton<IDataAccess, DataAccess>();
            services.AddTransient<IOrderService, OrderService>();
        }
    }
}
