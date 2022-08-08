using Microsoft.EntityFrameworkCore;
using OrderReceiver.Common.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderReceiver.Database
{
    public class OrderContext: DbContext
    {
        public OrderContext(DbContextOptions options) :
            base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Order> Orders { get; set; }
    }
}
