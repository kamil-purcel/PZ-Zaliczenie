using WarehouseMVC.Domain.Interfaces;
using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Infrastructure.Repositories;

public class AddressRepository : IAddressRepository
{
    private readonly Context _context;

    public AddressRepository(Context context)
    {
        _context = context;
    }
    
    public IQueryable<Address> GetAllAddresses()
    {
        return _context.Addresses;
    }

    public IQueryable<Address> GetAllAddressesByCustomerId(int customerId)
    {
        return _context.Addresses.Where(p => p.CustomerId == customerId);
    }

    public int AddAddress(Address address)
    {
        _context.Addresses.Add(address);
        _context.SaveChanges();
        return address.Id;
    }
    
}