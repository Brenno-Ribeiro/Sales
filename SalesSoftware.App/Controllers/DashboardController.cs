using Microsoft.AspNetCore.Mvc;

namespace SalesSoftware.App.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(ILogger<DashboardController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("dashboard")]
        public IActionResult Index()
        {
            ViewData["Title"] = "Dashboard";
            return View();
        }

    }
}
