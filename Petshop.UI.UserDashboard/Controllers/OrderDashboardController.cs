namespace Petshop.UI.UserDashboard.Controllers;

public class OrderDashboardController : Controller
{
    
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

	public OrderDashboardController(IMapper mapper, IMediator mediator)
	{
		this._mapper = mapper;
		this._mediator = mediator;
	}
	public IActionResult OrderList()
    {
        var orders = _mediator.Send(new GetOrdersListQuery()).GetAwaiter().GetResult();

        List<OrderListViewModel> model = _mapper.Map<List<OrderListViewModel>>(orders);
      
        return View(model);
    }
   	
	public IActionResult OrderDetails(int id)
    {

        GetOrderQuery order = new() {OrderId=id };
        var result = _mediator.Send(order).GetAwaiter().GetResult();
        var viewModel = _mapper.Map<OrderDetailsViewModel>(result);
        return View(viewModel);

    }
  public IActionResult DeleteOrder(int id)
    {
        DeleteOrderInfoCommand orderInfo = new()
        {
            OrderInfoId = id
        };
		var resultDeleted = _mediator.Send(orderInfo).GetAwaiter().GetResult();
        if (resultDeleted.IsSuccess)
        {
			
			return RedirectToAction(nameof(OrderList));
		}
        else
        {
            return View();
        }
		
    }


}
