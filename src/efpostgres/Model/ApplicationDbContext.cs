using Microsoft.EntityFrameworkCore;

namespace efpostgres.Model;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Age = 22, Name = "Aboba" },
            new User { Id = 2, Age = 42, Name = "Abobo" }
        );
    }
}