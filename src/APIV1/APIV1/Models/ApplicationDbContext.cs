using System.Net.Mime;
using Microsoft.EntityFrameworkCore;

namespace APIV1.Models;

public class ApplicationDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Supplier> Suppliers { get; set; } = null!;
    public DbSet<Image> Images { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
}