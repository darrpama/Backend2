using efpostgres.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string"
        + "'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// создаем два объекта User
User tom = new User { Name = "Tom", Age = 33 };
User alice = new User { Name = "Alice", Age = 26 };


app.MapGet("/api/users", async (ApplicationDbContext db) => await db.Users.ToListAsync());

app.Run();


// ApplicationDbContext can be used in ASP.NET Core controllers or other services through constructor injection:
// public class MyController
// {
//     private readonly ApplicationDbContext _context;

//     public MyController(ApplicationDbContext context)
//     {
//         _context = context;
//     }
// }
// The final result is an ApplicationDbContext instance created for each request and
// passed to the controller to perform a unit-of-work before being disposed when the request ends.