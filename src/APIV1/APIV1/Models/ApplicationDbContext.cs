using System.Net.Mime;
using Microsoft.EntityFrameworkCore;

namespace APIV1.Models;

public class ApplicationDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Address> Addresses { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // builder.Entity<Client>()
        //     .HasOne(c => c.Address)
        //     .WithOne(a => a.Client)
        //     .OnDelete(DeleteBehavior.Cascade); // Cascade delete for Client

        // builder.Entity<Supplier>()
        //     .HasOne(s => s.Address)
        //     .WithOne(a => a.Supplier)
        //     .OnDelete(DeleteBehavior.Cascade); // Cascade delete for Supplier
    }
}