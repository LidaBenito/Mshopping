using Petshop.UI.UserDashboard.Models.Orders;

namespace Petshop.UI.UserDashboard.Controllers;

public class OrderController : Controller
{
    private readonly OrderRepository orderRepository;
    private readonly OrderInfoRepository orderInfoRepository;
    private readonly IMapper mapper;

	public OrderController(OrderRepository orderRepository, IMapper mapper,OrderInfoRepository orderInfoRepository)
	{
		this.orderRepository = orderRepository;
		this.mapper = mapper;
		this.orderInfoRepository = orderInfoRepository;
	}
	public IActionResult OrderList()
    {
        var orders = orderRepository.GetUnsendOrders();
       
        List<OrderListViewModel> model = mapper.Map<List<OrderListViewModel>>(orders);
      
        return View(model);
    }
   	
	public IActionResult OrderDetails(int id)
    {
        var order = orderRepository.GetOrder(id);
        var viewModel = mapper.Map<OrderDetailsViewModel>(order);
        return View(viewModel);

    }
  public IActionResult DeleteOrder(int id)
    {
        var orderInfo= orderInfoRepository.GetOrderInfo(id);
        orderInfoRepository.Delete(orderInfo);
        var orderId = orderRepository.GetOrder(orderInfo.OrderId);
		return RedirectToAction(nameof(OrderDetails),new {id=orderId});
    }


}
