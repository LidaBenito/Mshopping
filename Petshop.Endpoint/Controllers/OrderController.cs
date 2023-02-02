
namespace Petshop.Endpoint.Controllers;

public class OrderController : BaseController
{
    private readonly OrderRepository orderRepository;
    private readonly Basket basket;
	private readonly IMediator _mediator;
	private readonly IMapper _mapper;

	public OrderController(OrderRepository orderRepository, Basket basket, IMapper mapper, IMediator mediator)
	{
		this.orderRepository = orderRepository;
		this.basket = basket;
		_mapper = mapper;
		_mediator = mediator;
	}
	public IActionResult Checkout()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Checkout(CheckoutViewModel viewModel)

    {
        if (!basket.Items.Any())
        {
            ModelState.AddModelError("", "کالایی موجود نیست");
        }
        if (ModelState.IsValid)
        {
            CheckoutOrderCommand orderCommand = _mapper.Map<CheckoutOrderCommand>(viewModel);
            var resut =_mediator.Send(orderCommand).GetAwaiter().GetResult();



			//TempData["price"] = order.Orders.Sum(p => p.Products.Price * p.Quantity);


			return RedirectToAction(nameof(Compelete), new { orderId = resut.Value });
        }
        else
        {

            return View(viewModel);
        }
    }
    public IActionResult Compelete(int orderId)
    {
		GetOrderQuery order= new() { OrderId=orderId};
		var orderResult = _mediator.Send(order).GetAwaiter().GetResult();
		if (orderResult.IsNotNull())
		{
			return View(orderResult);

		}
		else
		{
		return JsonFail();
		}
	
    }
    [HttpPost]
    public IActionResult Compelete(Order order)
    {
        return View(order);

    }
}
