
namespace Petshop.Endpoint.Controllers;

public class BasketController : Controller
{
	private readonly Basket sessionBasket;
	private readonly IMediator _mediator;
	private readonly IMapper _mapper;
	public BasketController(Basket sessionBasket, IMediator mediator, IMapper mapper)
	{
		this.sessionBasket = sessionBasket;
		_mediator = mediator;
		_mapper = mapper;
	}
	public IActionResult Index(string returnUrl)
	{
		BasketViewModel viewModel = new()
		{
			Basket = sessionBasket,
			returnURL = returnUrl

		};
		return View(viewModel);
	}
	public IActionResult AddToBasket(int productId, string returnUrl)
	{

		AddBasketCommand addProduct = new() { productId=productId};
		var productResult = _mediator.Send(addProduct).Result;
		if (productResult.IsSuccess)
		{
			return RedirectToAction(nameof(Index), new { returnUrl = returnUrl });

		}
		else
		{
			ModelState.AddModelError(string.Empty, productResult.Error);
		}
		return View();
	}



	public IActionResult RemoveFromBasket(int productId, string returnUrl)
	{
		RemoveBasketCommand removeProduct = new() { productId = productId };
		var removeResult = _mediator.Send(removeProduct).Result;
		
		return RedirectToAction("Index", new { returnUrl = returnUrl });

	}

}
