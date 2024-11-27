using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class ClientService
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

    public async Task<Client> GetClientAsync(Guid id)
    {
        try
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                throw new ArgumentException($"Invalid request: Client with id {id} does not exists.");
            }
            
            return client;
        }
        catch
        {
            throw;
        }
    }

    public async Task<List<Client>> GetAllClientsAsync()
    {
        try
        {
            var clients = await _context.Clients.ToListAsync();
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

}