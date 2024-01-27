using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WarehouseMVC.Application.Interfaces;
using WarehouseMVC.Application.Services;
using WarehouseMVC.Application.ViewModels.Customer;

namespace WarehouseMVC.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<ICustomerService, CustomerService>();
        services.AddTransient<IAddressService, AddressService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddTransient<IValidator<NewCustomerVm>, NewCustomerValidation>();
        return services;
    }
}