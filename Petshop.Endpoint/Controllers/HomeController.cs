
using Microsoft.Extensions.Options;
using Petshop.Application.Products.Query;
using Petshop.Utility.Paginations;
using System.Security.Cryptography;

namespace Petshop.Endpoint.Controllers;

public class HomeController : Controller
{
   
    private readonly PageInfo pageInfo;
	private readonly IMediator _mediator;
	private readonly IMapper _mapper;
	public HomeController(IOptions<PageInfo> pageInfo, IMapper mapper, IMediator mediator)
	{

		this.pageInfo = pageInfo.Value;
		_mapper = mapper;
		_mediator = mediator;
	}

	public IActionResult Index(string category = "", int pageNumber = 1)
    {
        var products = _mediator.Send(new GetProductsQuery()
        {
            PageNumber = pageNumber,
            PageSize = pageInfo.PageSize,
            Search = category
        }).GetAwaiter().GetResult();
		
        return View(products);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}