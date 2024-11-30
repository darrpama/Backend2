using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace api.Controllers;

public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet("{limit:int}/{offset:int}"), EndpointName("GetClients"), EndpointGroupName("Clients")]
    [ProducesResponseType(typeof(Client), 200)]
    public async Task<IActionResult> GetAllClients([FromQuery]int limit, [FromQuery]int offset)
    {
        try
        {
            var allClients = await _clientService.GetAllClientsAsync(limit, offset);
            return Ok(allClients);
        }
        catch (ArgumentException e)
        {
            return BadRequest($"{e.Message}");
        }
    }
    
    [HttpGet("{name}/{surname}"), EndpointName("GetClient"), EndpointGroupName("Clients")]
    public async Task<IActionResult> GetClient(string name, string surname)
    {
        try
        {
            var client = await _clientService.GetClientAsync(name, surname);
            return Ok(client);
        }
        catch (ArgumentException ex)
        {
            return BadRequest($"{ex.Message}");
        }
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteClient(Guid id)
    {
        try
        {
            var deletedClient = await _clientService.DeleteClientAsync(id);
            return Ok(deletedClient);
        }
        catch (ArgumentException ex)
        {
            return BadRequest($"{ex.Message}");
        }
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> AddClient([FromBody] Client client)
    {
        try
        {
            var addedClient = await _clientService.AddClientAsync(client);
            return Created($"/api/v1/clients/{addedClient.Id}", addedClient);
        }
        catch (ArgumentException ex)
        {
            return BadRequest($"{ex.Message}");
        }
    } 
    
}

// // Clients
// app.MapGet("/api/v1/clients", async () =>
// {
//     try
//     {
//         var clientService = scope.ServiceProvider.GetRequiredService<ClientService>();
//         var allClients = await clientService.GetAllClientsAsync();
//         return Results.Ok(allClients);
//     }
//     catch (ArgumentException ex)
//     {
//         return Results.BadRequest($"{ex.Message}");
//     }
// })
// .WithMetadata(new SwaggerOperationAttribute(summary: "Get all clients.", description: "Returns all clients."))
// .WithMetadata(new SwaggerTagAttribute(description:"aboba"));
//
// app.MapGet("/api/v1/clients/{id:Guid}", async (Guid id) =>
// {
//     try
//     {
//         var clientService = scope.ServiceProvider.GetRequiredService<ClientService>();
//         var client = await clientService.GetClientAsync(id);
//         return Results.Ok(client);
//     }
//     catch (ArgumentException ex)
//     {
//         return Results.BadRequest($"{ex.Message}");
//     }
// })
// .WithMetadata(new SwaggerOperationAttribute(summary: "Get one client.", description: "Returns one client if the existing id provided."));
//
// app.MapDelete("/api/v1/clients/{id:Guid}", async (Guid id) =>
// {
//     try
//     {
//         var clientService = scope.ServiceProvider.GetRequiredService<ClientService>();
//         var deletedClient = await clientService.DeleteClientAsync(id);
//         return Results.Ok(deletedClient);
//     }
//     catch (ArgumentException ex)
//     {
//         return Results.BadRequest($"{ex.Message}");
//     }
// })
// .WithMetadata(new SwaggerOperationAttribute(summary: "Delete one client.", description: "Delete exising client and returns it, otherwise returns empty response."));
//
// app.MapPost("/api/v1/clients/add", async (Client client) =>
// {
//     try
//     {
//         var clientService = scope.ServiceProvider.GetRequiredService<ClientService>();
//         var addedClient = await clientService.AddClientAsync(client);
//         return Results.Created($"/api/v1/clients/{addedClient.Id}", addedClient);
//     }
//     catch (ArgumentException ex)
//     {
//         return Results.BadRequest($"{ex.Message}");
//     }
// })
// .WithMetadata(new SwaggerOperationAttribute(summary: "Add one client.", description: "Returns client if the adding is done."));
