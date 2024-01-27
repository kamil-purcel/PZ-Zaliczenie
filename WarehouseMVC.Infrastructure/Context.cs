using Microsoft.EntityFrameworkCore;
using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Infrastructure;

public class Context : DbContext
{
    public Context(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<ContactDetail> ContactDetails { get; set; }
    public DbSet<ContactDetailType> ContactDetailTypes { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerContactInformation> CustomerContactInformations { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Customer>()
            .HasOne(a => a.CustomerContactInformation).WithOne(b => b.Customer)
            .HasForeignKey<CustomerContactInformation>(e => e.CustomerRef);
    }
}