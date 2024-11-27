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

app.MapGet("/api/v1/clients/{id:int}", async (int id, ApplicationDbContext db) =>
{
    var client = await db.Clients.FindAsync(id);
    
    if (client == null) return Results.NotFound(new { message = "Client not found." });
    
    return Results.Json(client);
});

app.MapDelete("/api/v1/clients/{id:int}", async (int id, ApplicationDbContext db) =>
{
    var client = await db.Clients.FindAsync(id);
    
    if (client == null) return Results.NotFound(new { message = "Client not found." });
    
    db.Clients.Remove(client);
    await db.SaveChangesAsync();
    return Results.Json(client);
});

app.MapPost("/api/v1/clients", async (Client client, ApplicationDbContext db) =>
{
    await db.Clients.AddAsync(client);
    await db.SaveChangesAsync();
    return client;
});

app.Run();
