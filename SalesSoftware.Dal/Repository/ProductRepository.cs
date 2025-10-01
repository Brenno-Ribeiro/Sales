using Dapper;
using SalesSoftware.Dal.Interfaces;
using SalesSoftware.Dal.Models;
using System.Data;

namespace SalesSoftware.Dal.Repository;

public  class ProductRepository : IProductRepository
{
    readonly IBaseConnection _baseConnection;
    public ProductRepository(IBaseConnection baseConnection)
    {
        _baseConnection = baseConnection;
    }

    public IEnumerable<ProductReport> GetProductTopSelling()
    {
        using (var conn = _baseConnection.CreateConnection())
        {
            return conn.Query<ProductReport>(
                "sp_top_selling_products",
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
