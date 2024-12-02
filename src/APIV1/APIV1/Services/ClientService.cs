using APIV1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace APIV1.Services;

public class PostgresClientRepository : IClientService
{
    private readonly ApplicationDbContext _context;

    public PostgresClientRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Client> AddClientAsync(Client client)
    {
        try
        {
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
            var client = _context.Clients
                .Include(c => c.Address)
                .FirstOrDefault(c => c.Id == id);
            if (client == null)
            {
                throw new ArgumentException($"Invalid request: Client with id {id} does not exists.");
            }
            
            // _context.Addresses.Remove(client.Address);
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
        if (limit < 0 || offset < 0)
        {
            throw new ArgumentException($"Invalid request: Limit {limit}, Offset {offset}.");
        }
        try
        {
            var clients = await _context.Clients
                .Skip(offset)
                .Take(limit)
                .Include(c => c.Address)
                .ToListAsync();
            
            if (!clients.Any())
            {
                throw new ArgumentException($"No clients found.");
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