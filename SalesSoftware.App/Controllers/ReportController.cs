using Microsoft.AspNetCore.Mvc;

namespace SalesSoftware.App.Controllers
{
    [Route("relatorios")]
    public class ReportController : Controller
    {
        private readonly ILogger<ReportController> _logger;

        public ReportController(ILogger<ReportController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Title"] = "Relat�rios";
            return View();
        }

        [HttpGet]
        [Route("pedido")]
        public IActionResult Orders()
        {
            ViewData["Title"] = "Relat�rio de Pedidos";
            return View();
        }

    }
}
