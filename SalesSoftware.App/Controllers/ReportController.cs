using Microsoft.AspNetCore.Mvc;
using SalesSoftware.App.Models.ViewModel;
using SalesSoftware.Bll.Intefaces;

namespace SalesSoftware.App.Controllers
{
    [Route("relatorios")]
    public class ReportController : Controller
    {
        private readonly ILogger<ReportController> _logger;
        private readonly ICustomerService _customerService;

        public ReportController(ILogger<ReportController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
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

            var customers = _customerService.GetAllCustomers();

            var model = new OrderReportViewModel
            {
                customers = customers.Select(c => new CustomerViewModel
                {
                    id = c.id,
                    name = c.name,
                    cpf = c.cpf,
                    registration_date = c.registration_date
                }).ToList()
            };

            return View(model);
        }


        [HttpPost]
        [Route("pedido")]
        public IActionResult Orders(OrderReportViewModel filter)
        {
            ViewData["Title"] = "Relatório de Pedidos";

            var customers = _customerService.GetAllCustomers();

            filter.customers = customers.Select(c => new CustomerViewModel
            {
                id = c.id,
                name = c.name,
                cpf = c.cpf,
                registration_date = c.registration_date
            }).ToList();

            return View(filter);
        }


        [HttpGet]
        [Route("produto")]
        public IActionResult Product()
        {
            ViewData["Title"] = "Relatório de Produtos";
            return View();

        }

        [HttpGet]
        [Route("cliente")]
        public IActionResult Customer()
        {
            ViewData["Title"] = "Relatório de Clientes";
            return View();
        }

    }
}
