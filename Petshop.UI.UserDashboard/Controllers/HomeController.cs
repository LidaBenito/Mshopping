using Microsoft.AspNetCore.Mvc;

namespace Petshop.UI.UserDashboard.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
