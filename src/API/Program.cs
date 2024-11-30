using API.Models;
using API.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Swashbuckle.AspNetCore.Annotations;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(options => 
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API for online shop",
        Version = "v1",
        Description = "An ASP.NET Core Web API for managing online shop",
        Contact = new OpenApiContact
        {
            Name = "darrpama",
            Url = new Uri("https://t.me/darrpama")
        }
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    options.EnableAnnotations();
});

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string"
        + "'DefaultConnection' not found.");


services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

services.AddAddressService();
services.AddClientService();
services.AddImageService();
services.AddProductService();
services.AddSupplierService();

var app = builder.Build();

app.UseRouting();
app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API for online shop v1");
});


// var scope = app.Services.CreateScope();

app.MapControllers();

// // Products
// app.MapGet("/api/v1/products", async () =>
// {
//     try
//     {
//         var productService = scope.ServiceProvider.GetRequiredService<ProductService>();
//         var allProducts = await productService.GetAllProductsAsync();
//         return Results.Ok(allProducts);
//     }
//     catch (ArgumentException ex)
//     {
//         return Results.BadRequest($"{ex.Message}");
//     }
// }).WithMetadata(new SwaggerOperationAttribute(summary: "Get all products.", description: "Returns all products."));
//
// app.MapGet("/api/v1/products/{id:Guid}", async (Guid id, ApplicationDbContext db) =>
// {
//     try
//     {
//         var productService = scope.ServiceProvider.GetRequiredService<ProductService>();
//         var client = await productService.GetProductAsync(id);
//         return Results.Ok(client);
//     }
//     catch (ArgumentException ex)
//     {
//         return Results.BadRequest($"{ex.Message}");
//     }
// })
// .WithMetadata(new SwaggerOperationAttribute(summary: "Get product by id.", description: "Returns one product if the existing id provided."));
//
// app.MapDelete("/api/v1/products/{id:Guid}", async (Guid id, ApplicationDbContext db) =>
// {
//     try
//     {
//         var productService = scope.ServiceProvider.GetRequiredService<ProductService>();
//         var deletedProduct = await productService.DeleteProductAsync(id);
//         return Results.Ok(deletedProduct);
//     }
//     catch (ArgumentException ex)
//     {
//         return Results.BadRequest($"{ex.Message}");
//     }
// })
// .WithMetadata(new SwaggerOperationAttribute(summary: "Delete product by id.", description: "Delete exising product and returns it, otherwise returns empty response."));
//
// app.MapPost("/api/v1/products/add", async (Product product, ApplicationDbContext db) =>
// {
//     try
//     {
//         var productService = scope.ServiceProvider.GetRequiredService<ProductService>();
//         var addedProduct = await productService.AddProductAsync(product);
//         return Results.Created($"/api/v1/clients/{addedProduct.Id}", addedProduct);
//     }
//     catch (ArgumentException ex)
//     {
//         return Results.BadRequest($"{ex.Message}");
//     }
// })
// .WithMetadata(new SwaggerOperationAttribute(summary: "Add one product.", description: "Returns product if the adding is done."));
//
//
// // Addresses
// app.MapGet("/api/v1/address", async () =>
// {
//     try
//     {
//         var addressService = scope.ServiceProvider.GetRequiredService<AddressService>();
//         var allAddresses = await addressService.GetAllAddressesAsync();
//         return Results.Ok(allAddresses);
//     }
//     catch (ArgumentException ex)
//     {
//         return Results.BadRequest($"{ex.Message}");
//     }
// }).WithMetadata(new SwaggerOperationAttribute(summary: "Get all addresses.", description: "Returns all addresses."));
//
// app.MapGet("/api/v1/address/{id:Guid}", async (Guid id, ApplicationDbContext db) =>
// {
//     try
//     {
//         var addressService = scope.ServiceProvider.GetRequiredService<AddressService>();
//         var client = await addressService.GetAddressAsync(id);
//         return Results.Ok(client);
//     }
//     catch (ArgumentException ex)
//     {
//         return Results.BadRequest($"{ex.Message}");
//     }
// })
// .WithMetadata(new SwaggerOperationAttribute(summary: "Get address by id.", description: "Returns one address if the existing id provided."));
//
// app.MapDelete("/api/v1/address/{id:Guid}", async (Guid id, ApplicationDbContext db) =>
// {
//     try
//     {
//         var addressService = scope.ServiceProvider.GetRequiredService<AddressService>();
//         var deletedAddress = await addressService.DeleteAddressAsync(id);
//         return Results.Ok(deletedAddress);
//     }
//     catch (ArgumentException ex)
//     {
//         return Results.BadRequest($"{ex.Message}");
//     }
// })
// .WithMetadata(new SwaggerOperationAttribute(summary: "Delete address by id.", description: "Delete exising address and returns it, otherwise returns empty response."));
//
// app.MapPost("/api/v1/address/add", async (Address address, ApplicationDbContext db) =>
// {
//     try
//     {
//         var addressService = scope.ServiceProvider.GetRequiredService<AddressService>();
//         var addedAddress = await addressService.AddAddressAsync(address);
//         return Results.Created($"/api/v1/address/{addedAddress.Id}", addedAddress);
//     }
//     catch (ArgumentException ex)
//     {
//         return Results.BadRequest($"{ex.Message}");
//     }
// })
// .WithMetadata(new SwaggerOperationAttribute(summary: "Add one address.", description: "Returns address if the adding is done."));
//
// // Suppliers
// app.MapGet("/api/v1/suppliers", async () =>
// {
//     try
//     {
//         var supplierService = scope.ServiceProvider.GetRequiredService<SupplierService>();
//         var allSuppliers = await supplierService.GetAllSuppliersAsync();
//         return Results.Ok(allSuppliers);
//     }
//     catch (ArgumentException ex)
//     {
//         return Results.BadRequest($"{ex.Message}");
//     }
// }).WithMetadata(new SwaggerOperationAttribute(summary: "Get all suppliers.", description: "Returns all suppliers."));
//
// app.MapGet("/api/v1/suppliers/{id:Guid}", async (Guid id, ApplicationDbContext db) =>
// {
//     try
//     {
//         var supplierService = scope.ServiceProvider.GetRequiredService<SupplierService>();
//         var client = await supplierService.GetSupplierAsync(id);
//         return Results.Ok(client);
//     }
//     catch (ArgumentException ex)
//     {
//         return Results.BadRequest($"{ex.Message}");
//     }
// })
// .WithMetadata(new SwaggerOperationAttribute(summary: "Get supplier by id.", description: "Returns one supplier if the existing id provided."));
//
// app.MapDelete("/api/v1/suppliers/{id:Guid}", async (Guid id, ApplicationDbContext db) =>
// {
//     try
//     {
//         var supplierService = scope.ServiceProvider.GetRequiredService<SupplierService>();
//         var deletedSupplier = await supplierService.DeleteSupplierAsync(id);
//         return Results.Ok(deletedSupplier);
//     }
//     catch (ArgumentException ex)
//     {
//         return Results.BadRequest($"{ex.Message}");
//     }
// })
// .WithMetadata(new SwaggerOperationAttribute(summary: "Delete supplier by id.", description: "Delete exising supplier and returns it, otherwise returns empty response."));
//
// app.MapPost("/api/v1/suppliers/add", async (Supplier supplier, ApplicationDbContext db) =>
// {
//     try
//     {
//         var supplierService = scope.ServiceProvider.GetRequiredService<SupplierService>();
//         var addedSupplier = await supplierService.AddSupplierAsync(supplier);
//         return Results.Created($"/api/v1/suppliers/{addedSupplier.Id}", addedSupplier);
//     }
//     catch (ArgumentException ex)
//     {
//         return Results.BadRequest($"{ex.Message}");
//     }
// })
// .WithMetadata(new SwaggerOperationAttribute(summary: "Add one supplier.", description: "Returns supplier if the adding is done."));
//
// // Images
// app.MapGet("/api/v1/images", async () =>
// {
//     try
//     {
//         var imageService = scope.ServiceProvider.GetRequiredService<ImageService>();
//         var allImages = await imageService.GetAllImagesAsync();
//         return Results.Ok(allImages);
//     }
//     catch (ArgumentException ex)
//     {
//         return Results.BadRequest($"{ex.Message}");
//     }
// }).WithMetadata(new SwaggerOperationAttribute(summary: "Get all images.", description: "Returns all images."));
//
// app.MapGet("/api/v1/images/{id:Guid}", async (Guid id, ApplicationDbContext db) =>
// {
//     try
//     {
//         var imageService = scope.ServiceProvider.GetRequiredService<ImageService>();
//         var client = await imageService.GetImageAsync(id);
//         return Results.Ok(client);
//     }
//     catch (ArgumentException ex)
//     {
//         return Results.BadRequest($"{ex.Message}");
//     }
// })
// .WithMetadata(new SwaggerOperationAttribute(summary: "Get image by id.", description: "Returns one image if the existing id provided."));
//
// app.MapDelete("/api/v1/images/{id:Guid}", async (Guid id, ApplicationDbContext db) =>
// {
//     try
//     {
//         var imageService = scope.ServiceProvider.GetRequiredService<ImageService>();
//         var deletedImage = await imageService.DeleteImageAsync(id);
//         return Results.Ok(deletedImage);
//     }
//     catch (ArgumentException ex)
//     {
//         return Results.BadRequest($"{ex.Message}");
//     }
// })
// .WithMetadata(new SwaggerOperationAttribute(summary: "Delete image by id.", description: "Delete exising image and returns it, otherwise returns empty response."));
//
// app.MapPost("/api/v1/images/add", async (Image image, ApplicationDbContext db) =>
// {
//     try
//     {
//         var imageService = scope.ServiceProvider.GetRequiredService<ImageService>();
//         var addedImage = await imageService.AddImageAsync(image);
//         return Results.Created($"/api/v1/images/{addedImage.Id}", addedImage);
//     }
//     catch (ArgumentException ex)
//     {
//         return Results.BadRequest($"{ex.Message}");
//     }
// })
// .WithMetadata(new SwaggerOperationAttribute(summary: "Add one image.", description: "Returns image if the adding is done."));
app.Run();
