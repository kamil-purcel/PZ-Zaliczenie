using AutoMapper;
using AutoMapper.QueryableExtensions;
using WarehouseMVC.Application.Interfaces;
using WarehouseMVC.Application.ViewModels.Customer;
using WarehouseMVC.Domain.Interfaces;
using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepo;
    private readonly IAddressRepository _addressRepo;
    
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository customerRepo, IAddressRepository addressRepo, IMapper mapper)
    {
        _customerRepo = customerRepo;
        _addressRepo = addressRepo;
        _mapper = mapper;
    }

    public ListCustomerForListVm GetAllCustomersForList()
    {
        var customers = _customerRepo.GetAllActiveCustomers()
            .ProjectTo<CustomerForListVm>(_mapper.ConfigurationProvider).ToList();

        var customerList = new ListCustomerForListVm
        {
            Customers = customers,
            Count = customers.Count
        };

        return customerList;
    }

    public ListCustomerForListVm GetAllCustomersForList(int pageSize, int pageNo, string searchString)
    {
        var customers = _customerRepo.GetAllActiveCustomers().Where(p => p.Name.Contains(searchString))
            .ProjectTo<CustomerForListVm>(_mapper.ConfigurationProvider).ToList();

        var customersToShow = customers.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();

        var customerList = new ListCustomerForListVm
        {
            PageSize = pageSize,
            CurrentPage = pageNo,
            SearchString = searchString,
            Customers = customersToShow,
            Count = customers.Count
        };

        return customerList;
    }


    public int AddCustomer(NewCustomerVm customerVm)
    {
        var cust = _mapper.Map<Customer>(customerVm);
        cust.IsActive = true;
        var id = _customerRepo.AddCustomer(cust);
        return id;
    }

    public CustomerDetailsVm GetCustomerDetails(int customerId)
    {
        var customer = _customerRepo.GetCustomer(customerId);
        var customerVm = _mapper.Map<CustomerDetailsVm>(customer);

        customerVm.PhoneNumbers = new List<ContactDetailListVm>();
        customerVm.Emails = new List<ContactDetailListVm>();

        customerVm.Addresses = _addressRepo.GetAllAddressesByCustomerId(customerId)
            .ProjectTo<AddressForDetailsVm>(_mapper.ConfigurationProvider).ToList();
        
        return customerVm;
    }

    public void DeleteCustomer(int id)
    {
        _customerRepo.DeleteCustomer(id);
    }

    public NewCustomerVm GetCustomerForEdit(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateCustomer(NewCustomerVm model)
    {
        var customer = _mapper.Map<Customer>(model);
        _customerRepo.UpdateCustomer(customer);
    }

    public NewCustomerVm GetCustomersForEdit(int id)
    {
        var customer = _customerRepo.GetCustomer(id);
        var customerVm = _mapper.Map<NewCustomerVm>(customer);

        return customerVm;
    }
}