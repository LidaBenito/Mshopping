using Petshop.Application.Products.Command.Add;
using Petshop.Application.Products.Query;
using Petshop.UI.UserDashboard.Models.Products;

namespace Petshop.UI.UserDashboard.Controllers;

public class ProductDashboardController : Controller
{
	private readonly CategoryRepository categoryRepository;
	private readonly IMapper mapper;
	private readonly IMediator  mediator;
	public ProductDashboardController(CategoryRepository categoryRepository, IMapper mapper, IMediator mediator)
	{
		this.categoryRepository = categoryRepository;
		this.mapper = mapper;
		this.mediator = mediator;
	}
	public IActionResult Index()
	{
		var products = mediator.Send(new GetProductsQuery()).GetAwaiter().GetResult();
		return View(products);
	}
	public IActionResult Add()
	{
		AddProductViewModel viewModel = new()
		{
			CategoryForDisplay = categoryRepository.GetAllCategories()
		};
		return View(viewModel);
	}
	[HttpPost]
	public IActionResult Add(AddProductViewModel model)
	{
		if (ModelState.IsValid)
		{
			AddProductCommand productCommand = mapper.Map<AddProductCommand>(model);
			var result = mediator.Send(productCommand).Result;
			if (result.IsSuccess)
			{
				return RedirectToAction(nameof(Index));

			}
			else
			{
				ModelState.AddModelError(string.Empty, result.Error);
			}
		}
		return RedirectToAction(nameof(Add));
	}
}
