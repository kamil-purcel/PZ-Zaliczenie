using WarehouseMVC.Domain.Interfaces;
using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly Context _context;

    public CustomerRepository(Context context)
    {
        _context = context;
    }

    public IQueryable<Customer> GetAllActiveCustomers()
    {
        return _context.Customers.Where(p => p.IsActive);
    }

    public Customer GetCustomer(int customerId)
    {
        return _context.Customers.FirstOrDefault(p => p.Id == customerId);
    }

    public int AddCustomer(Customer customer)
    {
        _context.Customers.Add(customer);
        _context.SaveChanges();
        return customer.Id;
    }

    public void UpdateCustomer(Customer customer)
    {
        _context.Attach(customer);
        _context.Entry(customer).Property("Name").IsModified = true;
        _context.Entry(customer).Property("NIP").IsModified = true;
        _context.Entry(customer).Property("Regon").IsModified = true;
        _context.Entry(customer).Property("CEOName").IsModified = true;
        _context.Entry(customer).Property("CEOLastName").IsModified = true;
        _context.SaveChanges();
    }

    public void DeleteCustomer(int id)
    {
        var customer = _context.Customers.Find(id);
        if (customer is not null)
        {
            customer.IsActive = false;
            _context.Attach(customer);
            _context.Entry(customer).Property("IsActive").IsModified = true;
            //_context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }

    public int GetCustomerByName(string addressVmCustomerName)
    {
        var customer = _context.Customers.FirstOrDefault(p => p.Name.Equals(addressVmCustomerName));
        
        return customer.Id;
    }
}