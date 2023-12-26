namespace Warehouse.Data;

using Microsoft.EntityFrameworkCore;
using Warehouse.Models;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
}