using Petshop.UI.UserDashboard.Models.Orders;

namespace Petshop.UI.UserDashboard.Controllers;

public class OrderController : Controller
{
    private readonly OrderRepository orderRepository;
    private readonly IMapper mapper;

    public OrderController(OrderRepository orderRepository
        , IMapper mapper)
    {
        this.orderRepository = orderRepository;
        this.mapper = mapper;
    }
    public IActionResult OrderList()
    {
        var orders = orderRepository.GetUnsendOrders();
       
        List<OrderListViewModel> model = mapper.Map<List<OrderListViewModel>>(orders);
      
        return View(model);
    }
   	
	public IActionResult OrderDetails(int id)
    {
        var order = orderRepository.Get(id);
        var viewModel = mapper.Map<OrderDetailsViewModel>(order);
        return View(viewModel);

    }
  


}
