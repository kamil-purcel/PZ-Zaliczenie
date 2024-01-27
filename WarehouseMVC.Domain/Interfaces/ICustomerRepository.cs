using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Domain.Interfaces;

public interface ICustomerRepository
{
    IQueryable<Customer> GetAllActiveCustomers();
    Customer GetCustomer(int customerId);

    int AddCustomer(Customer customer);
    void UpdateCustomer(Customer customer);
    void DeleteCustomer(int id);
    int GetCustomerByName(string addressVmCustomerName);
}