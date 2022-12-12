using Microsoft.AspNetCore.Mvc;
using Petshop.Contract.Orders;

namespace Petshop.UI.UserDashboard.Controllers
{
	public class OrderController : Controller
	{
		private readonly OrderRepository orderRepository;

		public OrderController(OrderRepository orderRepository)
		{
			this.orderRepository = orderRepository;
		}
		public IActionResult Index()
		{
			var model = orderRepository.GetUnsendOrders();
			return View(model);
		}
	}
}
