using API.Model;
using API.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Swashbuckle.AspNetCore.Annotations;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API for online shop v1"));
}

app.UseHttpsRedirection();

var scope = app.Services.CreateScope();

// Clients
app.MapGet("/api/v1/clients", async (ApplicationDbContext db) =>
{
    try
    {
        var clientService = scope.ServiceProvider.GetRequiredService<ClientService>();
        var allClients = await clientService.GetAllClientsAsync();
        return Results.Ok(allClients);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest($"{ex.Message}");
    }
})
.WithMetadata(new SwaggerOperationAttribute(summary: "Get all clients.", description: "Returns all clients."));

app.MapGet("/api/v1/clients/{id:Guid}", async (Guid id) =>
{
    try
    {
        var clientService = scope.ServiceProvider.GetRequiredService<ClientService>();
        var client = await clientService.GetClientAsync(id);
        return Results.Ok(client);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest($"{ex.Message}");
    }
})
.WithMetadata(new SwaggerOperationAttribute(summary: "Get one client.", description: "Returns one client if the existing id provided."));

app.MapDelete("/api/v1/clients/{id:Guid}", async (Guid id) =>
{
    try
    {
        var clientService = scope.ServiceProvider.GetRequiredService<ClientService>();
        var deletedClient = await clientService.DeleteClientAsync(id);
        return Results.Ok(deletedClient);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest($"{ex.Message}");
    }
})
.WithMetadata(new SwaggerOperationAttribute(summary: "Delete one client.", description: "Delete exising client and returns it, otherwise returns empty response."));

app.MapPost("/api/v1/clients/add", async (Client client) =>
{
    try
    {
        var clientService = scope.ServiceProvider.GetRequiredService<ClientService>();
        var addedClient = await clientService.AddClientAsync(client);
        return Results.Created($"/api/v1/clients/{addedClient.Id}", addedClient);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest($"{ex.Message}");
    }
})
.WithMetadata(new SwaggerOperationAttribute(summary: "Add one client.", description: "Returns client if the adding is done."));

// Products
app.MapGet("/api/v1/products", async (ApplicationDbContext db) =>
{
    try
    {
        var productService = scope.ServiceProvider.GetRequiredService<ProductService>();
        var allProducts = await productService.GetAllProductsAsync();
        return Results.Ok(allProducts);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest($"{ex.Message}");
    }
}).WithMetadata(new SwaggerOperationAttribute(summary: "Get all products.", description: "Returns all products."));

app.MapGet("/api/v1/products/{id:Guid}", async (Guid id, ApplicationDbContext db) =>
{
    try
    {
        var productService = scope.ServiceProvider.GetRequiredService<ProductService>();
        var client = await productService.GetProductAsync(id);
        return Results.Ok(client);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest($"{ex.Message}");
    }
})
.WithMetadata(new SwaggerOperationAttribute(summary: "Get product by id.", description: "Returns one product if the existing id provided."));

app.MapDelete("/api/v1/products/{id:Guid}", async (Guid id, ApplicationDbContext db) =>
{
    try
    {
        var productService = scope.ServiceProvider.GetRequiredService<ProductService>();
        var deletedProduct = await productService.DeleteProductAsync(id);
        return Results.Ok(deletedProduct);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest($"{ex.Message}");
    }
})
.WithMetadata(new SwaggerOperationAttribute(summary: "Delete product by id.", description: "Delete exising product and returns it, otherwise returns empty response."));

app.MapPost("/api/v1/products/add", async (Product product, ApplicationDbContext db) =>
{
    try
    {
        var productService = scope.ServiceProvider.GetRequiredService<ProductService>();
        var addedProduct = await productService.AddProductAsync(product);
        return Results.Created($"/api/v1/clients/{addedProduct.Id}", addedProduct);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest($"{ex.Message}");
    }
})
.WithMetadata(new SwaggerOperationAttribute(summary: "Add one product.", description: "Returns product if the adding is done."));

app.Run();
