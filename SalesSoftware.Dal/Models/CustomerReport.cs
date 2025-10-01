namespace SalesSoftware.Dal.Models;

public class CustomerReport
{
    public string? customer { get; set; }
    public string? product { get; set; }
    public int quantity { get; set; }
    public decimal total_item { get; set; }
    public decimal total_spent { get; set; }
    public DateTime order_date { get; set; }
}
