using OrderReceiver.Common.Models.Domain;
using OrderReceiver.Common.Models.Database;
using OrderReceiver.Database.Contracts;
using AutoMapper;

using DomOrder = OrderReceiver.Common.Models.Domain.Order;
using DBOrder = OrderReceiver.Common.Models.Database.Order;

namespace OrderReceiver.Services
{
    public class OrderService:IOrderService
    {
        private IDataAccess _dataAccess;
        private IMapper _mapper;
        public OrderService(IDataAccess dataAccess, IMapper mapper)
        {
            _dataAccess = dataAccess;
            _mapper = mapper;
        }

        public bool TryCreate(DomOrder order, out int orderNumber)
        {
            order.Number = GenerateOrderNumber();
            if(!_dataAccess.TryAdd<DBOrder, int>(_mapper.Map<DBOrder>(order)))
            {
                orderNumber = 0;
                return false;
            }
            orderNumber = order.Number;
            return true;
        }

        public bool TryGet(out DomOrder[] orders)
        {
            if (!_dataAccess.TryGet<DBOrder, int>(out DBOrder[] dbOrders))
            {
                orders = null;
                return false;
            }
            orders = _mapper.Map<DomOrder[]>(dbOrders);
            return true;
        }

        private int GenerateOrderNumber()
        {
            int num = Math.Abs((int)DateTime.Now.Ticks) % 1000000;
            return num;
        }
    }
}
