using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Petshop.Contract.Products;
using Petshop.Core.Baskets;
using Petshop.Endpoint.Models.Baskets;
using Petshop.Infra.Products;

namespace Petshop.Endpoint.Controllers
{
    public class BasketController : Controller
    {
        private readonly ProductRepository productRepository;

        public BasketController(ProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IActionResult Index(string returnUrl)
        {
            BasketViewModel viewModel = new()
            {
                Basket = GetBasket(),
                returnURL = returnUrl

            };
            return View(viewModel);
        }
        //[HttpPost]
        public IActionResult AddToBasket(int productId, string returnUrl)
        {
            var product = productRepository.GetProduct(productId);
            var basket = GetBasket();
            basket.AddItem(1, product);
            SaveBasket(basket);
            return RedirectToAction("Index", new {returnUrl=returnUrl});

        }



        public IActionResult RemoveFromBasket()
        {
            return RedirectToAction("Index");

        }
        private Basket GetBasket()
        {
            var currentBasket = HttpContext.Session.GetString("Basket");
            if (string.IsNullOrEmpty(currentBasket))
                return new Basket();
            return JsonConvert.DeserializeObject<Basket>(currentBasket);
        }
        private void SaveBasket(Basket basket)
        {
            HttpContext.Session.SetString("Basket", JsonConvert.SerializeObject(basket));
        }
    }
}
