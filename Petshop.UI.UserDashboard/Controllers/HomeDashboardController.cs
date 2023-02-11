using System.Diagnostics;

namespace Petshop.UI.UserDashboard.Controllers;

public class HomeDashboardController : Controller
{
    private readonly ILogger<HomeDashboardController> _logger;

    public HomeDashboardController(ILogger<HomeDashboardController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
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