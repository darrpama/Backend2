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
        modelBuilder.Entity<Client>().HasData(
            new Client { Id = Guid.NewGuid(), ClientName = "Tom", ClientSurname = "Holland", Birthday = new DateTimeOffset(1999, 8, 20, 0, 0, 0, new TimeSpan(0, 0, 0)), Gender = "Male", RegistrationDate = new DateTime(2015, 1, 10)},
            new Client { Id = Guid.NewGuid(), ClientName = "Alice", ClientSurname = "Sky", Birthday = new DateTimeOffset(1979, 4, 21, 0, 0, 0, new TimeSpan(0, 0, 0)), Gender = "Female", RegistrationDate = new DateTime(2017, 4, 11)},
            new Client { Id = Guid.NewGuid(), ClientName = "Sam", ClientSurname = "Polland", Birthday = new DateTimeOffset(1981, 2, 22, 0, 0, 0, new TimeSpan(0, 0, 0)), Gender = "Male", RegistrationDate = new DateTime(2019, 8, 1)}
        );
    }
}
