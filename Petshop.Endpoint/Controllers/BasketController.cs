

namespace Petshop.Endpoint.Controllers;

public class BasketController : Controller
{
    private readonly ProductRepository productRepository;
    private readonly Basket sessionBasket;

    public BasketController(ProductRepository productRepository,Basket sessionBasket)
    {
        this.productRepository = productRepository;
        this.sessionBasket = sessionBasket;
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
        var product = productRepository.GetProduct(productId);
        sessionBasket.AddItem(1, product);
       return RedirectToAction("Index", new { returnUrl = returnUrl });

    }



    public IActionResult RemoveFromBasket(int productId, string returnUrl)
    {
        var products = productRepository.GetProduct(productId);
        sessionBasket.RemoveItem(products);
        return RedirectToAction("Index", new { returnUrl = returnUrl });

    }
    
}
