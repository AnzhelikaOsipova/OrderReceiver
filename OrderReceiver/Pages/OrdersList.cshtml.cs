using Microsoft.AspNetCore.Mvc.RazorPages;
using OrderReceiver.Services;
using DomOrder = OrderReceiver.Common.Models.Domain.Order;
using VOrder = OrderReceiver.Common.Models.View.Order;
using AutoMapper;

namespace OrderReceiver.Pages
{
    public class OrdersListModel : PageModel
    {
        private IOrderService _orderService;
        private IMapper _mapper;

        public VOrder[] orders;

        public OrdersListModel(IMapper mapper, IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }
        public void OnGet()
        {
            if (_orderService.TryGet(out DomOrder[] items))
            {
                orders = _mapper.Map<VOrder[]>(items);
            }
        }
    }
}
