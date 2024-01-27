using AutoMapper;
using AutoMapper.QueryableExtensions;
using WarehouseMVC.Application.Interfaces;
using WarehouseMVC.Application.ViewModels.Customer;
using WarehouseMVC.Domain.Interfaces;
using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Application.Services;

public class AddressService:IAddressService
{
    
    private readonly ICustomerRepository _customerRepo;
    private readonly IAddressRepository _addressRepo;
    private readonly IMapper _mapper;

    public AddressService(ICustomerRepository customerRepo, IAddressRepository addressRepo,   IMapper mapper)
    {
        _customerRepo = customerRepo;
        _addressRepo = addressRepo;
        _mapper = mapper;
    }
    public List<AddressForListVm> GetAllAddressForList()
    {
        var addresses = _addressRepo.GetAllAddresses()
            .ProjectTo<AddressForListVm>(_mapper.ConfigurationProvider).ToList();

        foreach (var address in addresses)
        {
            address.CustomerName = _customerRepo.GetCustomer(address.CustomerId).Name;
        }

        return addresses;
    }
    
    public int AddAddress(NewAddressVm addressVm)
    {
        addressVm.CustomerId = _customerRepo.GetCustomerByName(addressVm.CustomerName);
        var address = _mapper.Map<Address>(addressVm);
        var id = _addressRepo.AddAddress(address);
        return id;
    }

}