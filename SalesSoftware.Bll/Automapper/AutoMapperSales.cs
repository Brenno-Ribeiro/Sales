using AutoMapper;
using SalesSoftware.Bll.Models;


namespace SalesSoftware.Bll.Automapper;

public class AutoMapperSales : Profile
{
    public AutoMapperSales()
    {
        CreateMap<Dal.Models.CustomerReport, CustomerReport>().ReverseMap();
        CreateMap<Dal.Models.ProductReport, ProductReport>().ReverseMap();
        CreateMap<Dal.Models.Customer, Customer>().ReverseMap();
    }
}
