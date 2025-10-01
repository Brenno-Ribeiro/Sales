using AutoMapper;
using SalesSoftware.Bll.Intefaces;
using SalesSoftware.Bll.Models;
using SalesSoftware.Dal.Interfaces;


namespace SalesSoftware.Bll.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public IEnumerable<ProductReport> GetProductTopSelling()
    {
        var productReports = _productRepository.GetProductTopSelling();
        return  _mapper.Map<IEnumerable<ProductReport>>(productReports);
    }

}