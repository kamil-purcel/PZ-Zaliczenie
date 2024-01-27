using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WarehouseMVC.Domain.Interfaces;
using WarehouseMVC.Infrastructure.Repositories;

namespace WarehouseMVC.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<ICustomerRepository, CustomerRepository>();
        services.AddTransient<IAddressRepository, AddressRepository>();

        // Get the connection string from appsettings.json
        var connectionString = configuration.GetConnectionString("DefaultConnection") ??
                               throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        // Add the database context registration with the "DefaultConnection" connection string
        services.AddDbContext<Context>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        return services;
    }
}