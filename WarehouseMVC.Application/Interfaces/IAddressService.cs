using WarehouseMVC.Application.ViewModels.Customer;
using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Application.Interfaces;

public interface IAddressService
{
    List<AddressForListVm> GetAllAddressForList();
    int AddAddress(NewAddressVm address);
}