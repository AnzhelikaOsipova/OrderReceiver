using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrderReceiver.Common.Models.View;
using OrderReceiver.Services;

namespace OrderReceiver.Pages
{
    public class NewOrderModel : PageModel
    {
        private IOrderService _orderService;
        private IMapper _mapper;

        [BindProperty]
        public Order NewOrder { get; set; }
        public string TestStr { get; set; } = "";

        public NewOrderModel(IMapper mapper, IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            if(!_orderService.TryCreate(_mapper.Map<OrderReceiver.Common.Models.Domain.Order>(NewOrder), 
                out int number))
            {
                TestStr = "Не удалось создать заказ";
                return;
            }
            TestStr = number.ToString();
        }
    }
}
