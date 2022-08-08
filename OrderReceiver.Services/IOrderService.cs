using OrderReceiver.Common.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderReceiver.Services
{
    public interface  IOrderService
    {
        public bool TryCreate(Order order, out int orderNumber);
        public bool TryGet(out Order[] orders);
    }
}
