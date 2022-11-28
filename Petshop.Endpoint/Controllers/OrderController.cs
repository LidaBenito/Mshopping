using Microsoft.AspNetCore.Mvc;

namespace Petshop.Endpoint.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Checkout()
        {
            return View();
        }
    }
}
