namespace Warehouse.Data;

using Microsoft.EntityFrameworkCore;
using Warehouse.Models;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Address> Adresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>()
            .HasOne(a => a.Customer)
            .WithMany(c => c.Addresses)
            .HasForeignKey(a => a.CustomerId);
    }
}