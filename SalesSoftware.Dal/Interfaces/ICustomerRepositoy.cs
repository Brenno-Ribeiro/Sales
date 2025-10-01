using SalesSoftware.Dal.Models;


namespace SalesSoftware.Dal.Interfaces;

public  interface ICustomerRepository
{
    IEnumerable<CustomerReport> GetOrderReposrtByCustomer(int customerId);
    IEnumerable<CustomerReport> GetCustomertHighValue();
}
