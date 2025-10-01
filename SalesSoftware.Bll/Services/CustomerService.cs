using AutoMapper;
using SalesSoftware.Bll.Intefaces;
using SalesSoftware.Bll.Models;
using SalesSoftware.Dal.Interfaces;


namespace SalesSoftware.Bll.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public IEnumerable<CustomerReport> GetCustomertHighValue()
    {
        var customerReports = _customerRepository.GetCustomertHighValue();
        return _mapper.Map<IEnumerable<CustomerReport>>(customerReports);
    }

    public IEnumerable<CustomerReport> GetOrderReposrtByCustomer(int customerId)
    {
        var customerReports = _customerRepository.GetOrderReposrtByCustomer(customerId);
        return  _mapper.Map<IEnumerable<CustomerReport>>(customerReports);
    }
}