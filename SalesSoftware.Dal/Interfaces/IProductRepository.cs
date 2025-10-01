using SalesSoftware.Dal.Models;

namespace SalesSoftware.Dal.Interfaces;

public interface IProductRepository
{
    IEnumerable<ProductReport> GetProductTopSelling();
}
