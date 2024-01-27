using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WarehouseMVC.Application.Interfaces;
using WarehouseMVC.Application.ViewModels.Customer;

namespace WarehouseMVC.Web.Controllers;

[Authorize]
public class CustomerController : Controller
{
    private readonly ICustomerService _customerService;
    private readonly IAddressService _addressService;

    public CustomerController(ICustomerService customerService, IAddressService addressService)
    {
        _customerService = customerService;
        _addressService = addressService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var model = _customerService.GetAllCustomersForList(5, 1, "");
        return View(model);
    }

    [HttpPost]
    public IActionResult Index(int pageSize, int? pageNo, string? searchString)
    {
        if (!pageNo.HasValue) pageNo = 1;

        if (searchString is null) searchString = string.Empty;

        var model = _customerService.GetAllCustomersForList(pageSize, pageNo.Value, searchString);
        return View(model);
    }

    public IActionResult ShowCustomerDetails(int id)
    {
        var model = _customerService.GetCustomerDetails(id);
        return View(model);
    }
    
    [Authorize(Roles = "Admin, SuperAdmin")]
    [HttpGet]
    public IActionResult AddCustomer()
    {
        return View(new NewCustomerVm());
    }

    [Authorize(Roles = "Admin, SuperAdmin")]
    [HttpPost]
    public IActionResult AddCustomer(NewCustomerVm customer)
    {
        var id = _customerService.AddCustomer(customer);
        return RedirectToAction("Index");
    }

    [Authorize(Roles = "Admin, SuperAdmin")]
    [HttpGet]
    public IActionResult EditCustomer(int id)
    {
        var customer = _customerService.GetCustomersForEdit(id);
        return View(customer);
    }

    [Authorize(Roles = "Admin, SuperAdmin")]
    [HttpPost]
    public IActionResult EditCustomer(NewCustomerVm customer)
    {
        _customerService.UpdateCustomer(customer);
        return RedirectToAction("Index");
    }


    [Authorize(Roles = "SuperAdmin")]
    public IActionResult DeleteCustomer(int id)
    {
        _customerService.DeleteCustomer(id);
        return RedirectToAction("Index");
    }

    
    [HttpGet]
    public IActionResult Addesses()
    {
        var model = _addressService.GetAllAddressForList();
        return View(model);
    }
    
    [Authorize(Roles = "Admin, SuperAdmin")]
    [HttpGet]
    public IActionResult AddAddess()
    {
        return View(new NewAddressVm());
    }

    [Authorize(Roles = "Admin, SuperAdmin")]
    [HttpPost]
    public IActionResult AddAddess(NewAddressVm address)
    {
        var id = _addressService.AddAddress(address);
        return RedirectToAction("Index");
    }
    
}