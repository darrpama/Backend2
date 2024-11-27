using API.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/v1/clients", async (ApplicationDbContext db) => await db.Clients.ToListAsync());

app.MapGet("/api/v1/clients/{id:Guid}", async (Guid id, ApplicationDbContext db) =>
{
    var client = await db.Clients.FindAsync(id);
    
    if (client == null) return Results.NotFound(new { message = "Client not found." });
    
    return Results.Json(client);
});

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

// app.MapPost("/api/v1/clients", async (Client client, ApplicationDbContext db) =>
// {
//     await db.Clients.AddAsync(client);
//     await db.SaveChangesAsync();
//     return client;
// });

app.Run();
