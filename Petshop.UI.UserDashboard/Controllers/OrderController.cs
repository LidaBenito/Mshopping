using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Petshop.Contract.Orders;
using Petshop.Contract.Orders.Services;
using Petshop.UI.UserDashboard.Models;

namespace Petshop.UI.UserDashboard.Controllers
{
	public class OrderController : Controller
	{
		private readonly OrderRepository orderRepository;
        private readonly OrderInfoService orderService;
        private readonly IMapper mapper;

        public OrderController(OrderRepository orderRepository,OrderInfoService orderService, IMapper mapper)
		{
			this.orderRepository = orderRepository;
            this.orderService = orderService;
            this.mapper = mapper;
        }
		public IActionResult OrderList()
		{
            var orders=orderRepository.GetUnsendOrders();
			var products = orderService.GetProductsByOrders();
			List< OrderListViewModel> model = mapper.Map< List<OrderListViewModel>>(orders);
			//foreach (var item in products)
			//{
			//	model.Select(S => S.Product).Append(item.Name);
			//}
            return View(model);
		}
		
	}
}
