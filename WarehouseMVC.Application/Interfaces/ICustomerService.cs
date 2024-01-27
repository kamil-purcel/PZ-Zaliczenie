using WarehouseMVC.Application.ViewModels.Customer;

namespace WarehouseMVC.Application.Interfaces;

public interface ICustomerService
{
    ListCustomerForListVm GetAllCustomersForList();
    ListCustomerForListVm GetAllCustomersForList(int pageSize, int pageNo, string searchString);

    int AddCustomer(NewCustomerVm customerVm);

    CustomerDetailsVm GetCustomerDetails(int customerId);

    void DeleteCustomer(int id);

    NewCustomerVm GetCustomerForEdit(int id);

    void UpdateCustomer(NewCustomerVm model);

    NewCustomerVm GetCustomersForEdit(int id);
}