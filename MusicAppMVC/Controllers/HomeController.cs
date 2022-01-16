using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MusicAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("opened Home page");
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("opened privacy page");
            return View();
        }

        public IActionResult ErrorLogin()
        {
            _logger.LogInformation("failed to login");
            return View();
        }
    }
}
