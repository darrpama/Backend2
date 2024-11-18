using Microsoft.EntityFrameworkCore;

namespace API.Model;

public class ApplicationDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
