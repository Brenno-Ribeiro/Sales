using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
using SalesSoftware.App.Models.ViewModel;
using SalesSoftware.Bll.Intefaces;

namespace SalesSoftware.App.Controllers
{
    [Route("relatorios")]
    public class ReportController : Controller
    {
        private readonly ILogger<ReportController> _logger;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;

        public ReportController(ILogger<ReportController> logger, ICustomerService customerService, IProductService productService)
        {
            _logger = logger;
            _customerService = customerService;
            _productService = productService;
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


           var productList = _productService.GetProductTopSelling();

            string reportPath = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "PedidosMaisVendidos.rdlc");
            LocalReport report = new LocalReport();

            using (var fs = new FileStream(reportPath, FileMode.Open, FileAccess.Read))
            {
                report.LoadReportDefinition(fs);
            }

            report.DataSources.Add(new ReportDataSource("DataSet1", productList));

            // Renderiza PDF (ou "PDF" / "Excel" / "WORDOPENXML")
            var pdf = report.Render("PDF");

            return File(pdf, "application/pdf", "PedidosMaisVendidos.pdf");

        }

        [HttpGet]
        [Route("cliente")]
        public IActionResult Customer()
        {
            ViewData["Title"] = "Relatório de Clientes";

            var customer = _customerService.GetCustomertHighValue();

            string reportPath = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "ClienteAcima1000.rdlc");
            LocalReport report = new LocalReport();

            using (var fs = new FileStream(reportPath, FileMode.Open, FileAccess.Read))
            {
                report.LoadReportDefinition(fs);
            }

            report.DataSources.Add(new ReportDataSource("DataSet1", customer));

            // Renderiza PDF (ou "PDF" / "Excel" / "WORDOPENXML")
            var pdf = report.Render("PDF");

            return File(pdf, "application/pdf", "ClienteAcima1000.pdf");
        }

    }
}
