namespace SalesSoftware.App.Models.ViewModel
{
    public class OrderReportViewModel
    {
        public int? customer_id { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }

        public List<CustomerViewModel> customers { get; set; } = new();
    }

   
}
