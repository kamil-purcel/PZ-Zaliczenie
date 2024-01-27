using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Domain.Interfaces;

public interface IAddressRepository
{
    IQueryable<Address> GetAllAddresses();
    IQueryable<Address> GetAllAddressesByCustomerId(int customerId);
    int AddAddress(Address address);
}