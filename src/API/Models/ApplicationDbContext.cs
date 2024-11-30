using Microsoft.EntityFrameworkCore;
using System.Text.Json;

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

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Client>().HasData(
    //         new Client
    //         {
    //             Id = Guid.NewGuid(),
    //             ClientName = "Tom",
    //             ClientSurname = "Holland",
    //             Birthday = new DateTimeOffset(1999, 8, 20, 0, 0, 0, new TimeSpan(0, 0, 0)),
    //             Gender = "Male",
    //             RegistrationDate = new DateTimeOffset(2015, 1, 10, 0, 0, 0, new TimeSpan(0, 0, 0)),
    //             AddressId = Guid.Parse("3ab3bc51-5391-482a-9027-19330f029760")
    //         },
    //         new Client
    //         {
    //             Id = Guid.NewGuid(),
    //             ClientName = "Alice",
    //             ClientSurname = "Sky",
    //             Birthday = new DateTimeOffset(1979, 4, 21, 0, 0, 0, new TimeSpan(0, 0, 0)),
    //             Gender = "Female",
    //             RegistrationDate = new DateTimeOffset(2017, 4, 11, 0, 0, 0, new TimeSpan(0, 0, 0)),
    //             AddressId = Guid.Parse("ce006a62-c7c7-4ddc-911a-f6da5e946a5a")
    //         },
    //         new Client
    //         {
    //             Id = Guid.NewGuid(),
    //             ClientName = "Sam",
    //             ClientSurname = "Polland",
    //             Birthday = new DateTimeOffset(1981, 2, 22, 0, 0, 0, new TimeSpan(0, 0, 0)),
    //             Gender = "Male",
    //             RegistrationDate = new DateTimeOffset(2019, 8, 1, 0, 0, 0, new TimeSpan(0, 0, 0)),
    //             AddressId = Guid.Parse("20b68e72-492b-4ced-9a6a-3c1f157045c2")
    //         }
    //     );
    //     
    //     modelBuilder.Entity<Product>().HasData(
    //         new Product
    //         {
    //             Id = Guid.NewGuid(),
    //             Name = "Milk",
    //             Category = "Food",
    //             Price = 3.23,
    //             AvailableStock = 100,
    //             LastUpdateDate = new DateTimeOffset(2015, 1, 10, 0, 0, 0, new TimeSpan(0, 0, 0)),
    //             SupplierId = Guid.Parse("ea0293ba-ec51-41b1-b67b-6ec518f1723e"),
    //             ImageId = Guid.Parse("167d0be7-30fe-476d-af34-3ce9dcdef22a")
    //         },
    //         new Product
    //         {
    //             Id = Guid.NewGuid(),
    //             Name = "Eggs",
    //             Category = "Food",
    //             Price = 5.55,
    //             AvailableStock = 234,
    //             LastUpdateDate = new DateTimeOffset(2017, 4, 11, 0, 0, 0, new TimeSpan(0, 0, 0)),
    //             SupplierId = Guid.Parse("d289e122-a531-4a91-8d9b-656e003f0612"),
    //             ImageId = Guid.Parse("77d95bc4-9eb8-43cb-bed5-f191e34e206c")
    //         },
    //         new Product
    //         {
    //             Id = Guid.NewGuid(),
    //             Name = "Meat",
    //             Category = "Food",
    //             Price = 14.46,
    //             AvailableStock = 12,
    //             LastUpdateDate = new DateTimeOffset(2019, 8, 12, 0, 0, 0, new TimeSpan(0, 0, 0)),
    //             SupplierId = Guid.Parse("41c98aa5-e98d-4dff-8b83-5cb29b20d4d6"),
    //             ImageId = Guid.Parse("77d95bc4-9eb8-43cb-bed5-f191e34e206c")
    //         }
    //     );
    //     
    //     modelBuilder.Entity<Supplier>().HasData(
    //         new Supplier
    //         {
    //             Id = Guid.Parse("ea0293ba-ec51-41b1-b67b-6ec518f1723e"),
    //             AddressId = Guid.Parse("a2fab490-42b9-4467-a4fe-d54cc5dbbbf2"),
    //             PhoneNumber = "+441142762024"
    //         },
    //         new Supplier
    //         {
    //             Id = Guid.Parse("d289e122-a531-4a91-8d9b-656e003f0612"),
    //             AddressId = Guid.Parse("014f360a-c5a7-4c1c-afdf-7fddef43c3a0"),
    //             PhoneNumber = "+443003038642"
    //         },
    //         new Supplier
    //         {
    //             Id = Guid.Parse("41c98aa5-e98d-4dff-8b83-5cb29b20d4d6"),
    //             AddressId = Guid.Parse("5d6057f3-2e94-43be-bd21-d96f94f70eb2"),
    //             PhoneNumber = "+443453011151"
    //         }
    //     );
    //     Image? image1 = new Image();
    //     Image? image2 = new Image();
    //     using (FileStream fs = new FileStream("Assets/image1.json", FileMode.Open))
    //     {
    //         try
    //         {
    //             image1 = JsonSerializer.Deserialize<Image>(fs);
    //         }
    //         catch (Exception ex)
    //         {
    //             Console.WriteLine(ex.Message);
    //         }
    //     }
    //     using (FileStream fs = new FileStream("Assets/image2.json", FileMode.Open))
    //     {
    //         try
    //         {
    //             image2 = JsonSerializer.Deserialize<Image>(fs);
    //         }
    //         catch (Exception ex)
    //         {
    //             Console.WriteLine(ex.Message);
    //         }
    //     }
    //     if (image1 != null && image2 != null)
    //     {
    //         modelBuilder.Entity<Image>().HasData(
    //             image1,
    //             image2
    //         );
    //     }
    //     
    //     modelBuilder.Entity<Address>().HasData(
    //         new Address
    //         {
    //             Id = Guid.Parse("3ab3bc51-5391-482a-9027-19330f029760"),
    //             Country = "UK",
    //             City = "Birmingham",
    //             Street = "69 St Agatha's Rd"
    //         },
    //         new Address
    //         {
    //             Id = Guid.Parse("ce006a62-c7c7-4ddc-911a-f6da5e946a5a"),
    //             Country = "UK",
    //             City = "Conventry",
    //             Street = "3 Welford Pl"
    //         },
    //         new Address
    //         {
    //             Id = Guid.Parse("20b68e72-492b-4ced-9a6a-3c1f157045c2"),
    //             Country = "UK",
    //             City = "Worcester",
    //             Street = "88 Vincent Rd"
    //         },
    //         new Address
    //         {
    //             Id = Guid.Parse("a2fab490-42b9-4467-a4fe-d54cc5dbbbf2"),
    //             Country = "UK",
    //             City = "Liverpool",
    //             Street = "13 Blantyre Rd"
    //         },
    //         new Address
    //         {
    //             Id = Guid.Parse("014f360a-c5a7-4c1c-afdf-7fddef43c3a0"),
    //             Country = "UK",
    //             City = "Manchester",
    //             Street = "5 Carina Pl"
    //         },
    //         new Address
    //         {
    //             Id = Guid.Parse("5d6057f3-2e94-43be-bd21-d96f94f70eb2"),
    //             Country = "UK",
    //             City = "Sheffield",
    //             Street = "109 Devonshire St"
    //         }
    //     );
    // }
}
