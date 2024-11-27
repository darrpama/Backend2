using API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Npgsql.Internal;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => 
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

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API for online shop v1"));
}

app.UseHttpsRedirection();

app.MapGet("/api/v1/clients", async (ApplicationDbContext db) =>
{
    return await db.Clients.ToListAsync();
})
.WithMetadata(new SwaggerOperationAttribute(summary: "Get all clients.", description: "Returns all clients in json array."));

app.MapGet("/api/v1/clients/{id:Guid}", async (Guid id, ApplicationDbContext db) =>
{
    var client = await db.Clients.FindAsync(id);

    if (client == null) return Results.NotFound(new { message = "Client not found." });

    return Results.Json(client);
})
.WithMetadata(new SwaggerOperationAttribute(summary: "Get one client.", description: "Returns one client if the existing id provided."))
.WithMetadata(new SwaggerResponseAttribute(StatusCodes.Status404NotFound));

app.MapDelete("/api/v1/clients/{id:Guid}", async (Guid id, ApplicationDbContext db) =>
{
    var client = await db.Clients.FindAsync(id);
    
    if (client == null) return Results.NotFound(new { message = "Client not found." });
    
    db.Clients.Remove(client);
    await db.SaveChangesAsync();
    return Results.Json(client);
});

app.MapPost("/api/v1/clients/add", async (Client client, ApplicationDbContext db) =>
{
    await db.Clients.AddAsync(client);
    await db.SaveChangesAsync();
    return client;
});


app.MapGet("/api/v1/products", async (ApplicationDbContext db) => await db.Products.ToListAsync());

app.MapGet("/api/v1/products/{id:Guid}", async (Guid id, ApplicationDbContext db) =>
{
    var product = await db.Products.FindAsync(id);
    
    if (product == null) return Results.NotFound(new { message = "Product not found." });
    
    return Results.Json(product);
});

app.MapDelete("/api/v1/products/{id:Guid}", async (Guid id, ApplicationDbContext db) =>
{
    var product = await db.Products.FindAsync(id);
    
    if (product == null) return Results.NotFound(new { message = "product not found." });
    
    db.Products.Remove(product);
    await db.SaveChangesAsync();
    return Results.Json(product);
});

app.MapPost("/api/v1/products/add", async (Product product, ApplicationDbContext db) =>
{
    await db.Products.AddAsync(product);
    await db.SaveChangesAsync();
    return product;
});

app.Run();
