using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace API.Services;

public class ClientService : IClientService
{
    private readonly ApplicationDbContext _context;

    public ClientService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Client> AddClientAsync(Client client)
    {
        try
        {
            var address = await _context.Addresses.FindAsync(client.AddressId);
            if (address == null)
            {
                throw new ArgumentException($"Invalid request: Address with id {client.AddressId} does not exists.");
            }
            
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return client;
        }
        catch
        {
            throw;
        }
    }

    public async Task<Client> DeleteClientAsync(Guid id)
    {
        try
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                throw new ArgumentException($"Invalid request: Client with id {id} does not exists.");
            }
            
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return client;
        }
        catch
        {
            throw;
        }
    }

    public async Task<Client> GetClientAsync(string name, string surname)
    {
        try
        {
            var client = await _context.Clients.FirstOrDefaultAsync((c) => c.ClientName == name && c.ClientSurname == surname);
            if (client == null)
            {
                throw new ArgumentException($"Invalid request: Client with name {name} and surname {surname} does not exists.");
            }
            
            return client;
        }
        catch
        {
            throw;
        }
    }

    public async Task<List<Client>> GetAllClientsAsync(int limit, int offset)
    {
        try
        {
            var clients = await _context.Clients
                .Skip(offset)
                .Take(limit)
                .ToListAsync();
            
            if (clients == null)
            {
                throw new ArgumentException($"Invalid request: Clients relation does not exists.");
            }
            
            return clients;
        }
        catch
        {
            throw;
        }
    }

    public async Task<Client> ChangeClientAddressAsync(Guid id, Address address)
    {
        try
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                throw new ArgumentException($"Invalid request: Client with id {id} does not exists.");
            }

            client.Address = address;
            await _context.SaveChangesAsync();
            return client;
        }
        catch
        {
            throw;
        }
    }
}