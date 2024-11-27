using Microsoft.EntityFrameworkCore;

namespace API.Model;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().HasData(
            new Client
            {
                Id = Guid.NewGuid(),
                ClientName = "Tom",
                ClientSurname = "Holland",
                Birthday = new DateTimeOffset(1999, 8, 20, 0, 0, 0, new TimeSpan(0, 0, 0)),
                Gender = "Male",
                RegistrationDate = new DateTime(2015, 1, 10),
                AddressId = "3ab3bc51-5391-482a-9027-19330f029760"
            },
            new Client
            {
                Id = Guid.NewGuid(),
                ClientName = "Alice",
                ClientSurname = "Sky",
                Birthday = new DateTimeOffset(1979, 4, 21, 0, 0, 0, new TimeSpan(0, 0, 0)),
                Gender = "Female",
                RegistrationDate = new DateTime(2017, 4, 11),
                AddressId = "ce006a62-c7c7-4ddc-911a-f6da5e946a5a"
            },
            new Client
            {
                Id = Guid.NewGuid(),
                ClientName = "Sam",
                ClientSurname = "Polland",
                Birthday = new DateTimeOffset(1981, 2, 22, 0, 0, 0, new TimeSpan(0, 0, 0)),
                Gender = "Male",
                RegistrationDate = new DateTime(2019, 8, 1),
                AddressId = "20b68e72-492b-4ced-9a6a-3c1f157045c2"
            }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Milk",
                Category = "Food",
                Price = 3.23,
                AvailableStock = 100,
                LastUpdateDate = new DateTime(2015, 1, 10),
                SupplierId = "ea0293ba-ec51-41b1-b67b-6ec518f1723e",
                ImageId = "167d0be7-30fe-476d-af34-3ce9dcdef22a"
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Eggs",
                Category = "Food",
                Price = 5.55,
                AvailableStock = 234,
                LastUpdateDate = new DateTime(2017, 4, 11),
                SupplierId = "d289e122-a531-4a91-8d9b-656e003f0612",
                ImageId = "77d95bc4-9eb8-43cb-bed5-f191e34e206c" 
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Meat",
                Category = "Food",
                Price = 14.46,
                AvailableStock = 12,
                LastUpdateDate = new DateTime(2019, 8, 12),
                SupplierId = "41c98aa5-e98d-4dff-8b83-5cb29b20d4d6",
                ImageId = "77d95bc4-9eb8-43cb-bed5-f191e34e206c" 
            }
        );

        modelBuilder.Entity<Supplier>().HasData(
            new Supplier
            {
                Id = "ea0293ba-ec51-41b1-b67b-6ec518f1723e",
                AddressId = "a2fab490-42b9-4467-a4fe-d54cc5dbbbf2",
                PhoneNumber = "+441142762024"
            },
            new Supplier
            {
                Id = "d289e122-a531-4a91-8d9b-656e003f0612",
                AddressId = "014f360a-c5a7-4c1c-afdf-7fddef43c3a0",
                PhoneNumber = "+443003038642"
            },
            new Supplier
            {
                Id = "41c98aa5-e98d-4dff-8b83-5cb29b20d4d6",
                AddressId = "5d6057f3-2e94-43be-bd21-d96f94f70eb2",
                PhoneNumber = "+443453011151"
            }
        );

        Image image1 = new Image();
        Image image2 = new Image();
        using (FileStream fs = new FileStream("Assets/image1.json", FileMode.Open))
        {
            image1 = JsonDeserializer.Deserialize<Image>(fs);
        }
        using (FileStream fs = new FileStream("Assets/image2.json", FileMode.Open))
        {
            image2 = JsonDeserializer.Deserialize<Image>(fs);
        }
        modelBuilder.Entity<Image>().HasData(
            image1,
            image2
        );

        modelBuilder.Entity<Address>().HasData(
            new Address
            {
                Id = "3ab3bc51-5391-482a-9027-19330f029760",
                Country = "UK",
                City = "Birmingham",
                Street = "69 St Agatha's Rd"
            },
            new Address
            {
                Id = "ce006a62-c7c7-4ddc-911a-f6da5e946a5a",
                Country = "UK",
                City = "Conventry",
                Street = "3 Welford Pl"
            },
            new Address
            {
                Id = "20b68e72-492b-4ced-9a6a-3c1f157045c2",
                Country = "UK",
                City = "Worcester",
                Street = "88 Vincent Rd"
            },
            new Address
            {
                Id = "a2fab490-42b9-4467-a4fe-d54cc5dbbbf2",
                Country = "UK",
                City = "Liverpool",
                Street = "13 Blantyre Rd"
            },
            new Address
            {
                Id = "014f360a-c5a7-4c1c-afdf-7fddef43c3a0",
                Country = "UK",
                City = "Manchester",
                Street = "5 Carina Pl"
            },
            new Address
            {
                Id = "5d6057f3-2e94-43be-bd21-d96f94f70eb2",
                Country = "UK",
                City = "Sheffield",
                Street = "109 Devonshire St"
            }
        );
    }
}
