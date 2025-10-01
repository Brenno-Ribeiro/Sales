using Dapper;
using SalesSoftware.Dal.Interfaces;
using SalesSoftware.Dal.Models;
using System.Data;

namespace SalesSoftware.Dal.Repository;

public  class CustomerRepository : ICustomerRepository
{
    readonly IBaseConnection _baseConnection;
    public CustomerRepository(IBaseConnection baseConnection)
    {
        _baseConnection = baseConnection;
    }

    public IEnumerable<CustomerReport> GetCustomertHighValue()
    {
        using (var conn = _baseConnection.CreateConnection())
        {
            return conn.Query<CustomerReport>(
                "sp_high_value_customers",
                commandType: CommandType.StoredProcedure
            );
        }
    }

    public IEnumerable<CustomerReport> GetOrderReposrtByCustomer(int customerId)
    {
        using (var conn = _baseConnection.CreateConnection())
        {
            return conn.Query<CustomerReport>(
                "sp_report_orders_per_customer",      
                new { customer_id = customerId },         
                commandType: CommandType.StoredProcedure  
            );
        }
    }

}
