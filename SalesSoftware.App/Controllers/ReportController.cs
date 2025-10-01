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
            ViewData["Title"] = "Relatórios";
            return View();
        }

        [HttpGet]
        [Route("pedido")]
        public IActionResult Orders()
        {
            ViewData["Title"] = "Relatório de Pedidos";
            return View();
        }

    }
}
