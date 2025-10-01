using SalesSoftware.Bll.Models;

namespace SalesSoftware.Bll.Intefaces;

public  interface ICustomerService
{
    IEnumerable<CustomerReport> GetOrderReposrtByCustomer(int customerId);
    IEnumerable<CustomerReport> GetCustomertHighValue();
}

