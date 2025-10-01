using SalesSoftware.Bll.Models;

namespace SalesSoftware.Bll.Intefaces
{
    public  interface IProductService
    {
        IEnumerable<ProductReport> GetProductTopSelling();
    }
}
