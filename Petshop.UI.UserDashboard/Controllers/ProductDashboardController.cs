using Microsoft.Extensions.Options;
using Petshop.Utility.Paginations;
using System.Text;

namespace Petshop.UI.UserDashboard.Controllers;

public class ProductDashboardController : Controller
{
    private readonly PageInfo pageInfo;
	private readonly CategoryRepository categoryRepository;
	private readonly IMapper mapper;
	private readonly IMediator  mediator;
	public ProductDashboardController(CategoryRepository categoryRepository, IMapper mapper,
		IMediator mediator, IOptions<PageInfo> pageInfo)
	{
		this.categoryRepository = categoryRepository;
		this.mapper = mapper;
		this.mediator = mediator;
		this.pageInfo = pageInfo.Value;
	}
	public IActionResult Index(string category = "", int pageNumber = 1)
	{
		var products  = mediator.Send(new GetProductsQuery()
		{
			PageNumber = pageNumber,
			PageSize = pageInfo.PageSize,
			Search = category
		}).GetAwaiter().GetResult();
		//foreach (var item in products.Data)
		//{
		//	if (item.Imagee != null)
		//	{

		//		string? img = "";
		//		img = item.Imagee.Img;
		//		//byte[] bytes = (byte[])img.Rows
		//		byte[] bytes = Encoding.ASCII.GetBytes(img);
		//		MemoryStream ms = new MemoryStream(bytes);
		//		string imgString = Convert.ToBase64String(bytes);
		//		item.Imagee.Img = String.Format("data:image/jpeg;base64,{0}", imgString);

		//	}
		//}
		return View(products);
	}
	public IActionResult Add()
	{
		ProductViewModel viewModel = new()
		{
			CategoryForDisplay = categoryRepository.GetAllCategories()
		};
		return View(viewModel);
	}
	[HttpPost]
	public IActionResult Add(ProductViewModel model)
	{
		if (model != null)
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
