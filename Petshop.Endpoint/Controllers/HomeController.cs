using Microsoft.AspNetCore.Mvc;
using Petshop.Contract.Products;
using Petshop.Endpoint.Models;
using System.Diagnostics;

namespace Petshop.Endpoint.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductRepository productRepository;

        public HomeController(ILogger<HomeController> logger, ProductRepository productRepository)
        {
            _logger = logger;
            this.productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var products = productRepository.Products();
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
}