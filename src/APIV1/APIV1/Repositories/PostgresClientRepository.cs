using APIV1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace APIV1.Repositories;

public class PostgresClientRepository : IClientRepository
{
    private readonly ApplicationDbContext _context;

    public PostgresClientRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Client?> CreateClientAsync(Client client)
    {
        await _context.Clients.AddAsync(client);
        await _context.SaveChangesAsync();
        return client;
    }
    
    public async Task<Client?> ReadClientAsync(string name, string surname)
    {
        var client = await _context.Clients.FirstOrDefaultAsync((c) => c.ClientName == name && c.ClientSurname == surname);
        if (client is not null)
        {
            await _context.Entry(client).Reference(c => c.Address).LoadAsync();
        }
        return client;
    }
    
    public async Task<Client?> ReadClientAsync(Guid id)
    {
        var client = await _context.Clients.FirstOrDefaultAsync((c) => c.Id == id);
        return client;
    }

    public async Task<List<Client>> ReadAllClientsAsync(int limit, int offset)
    {
        var clients = await _context.Clients
            .OrderBy(c => c.Id)
            .Skip(offset)
            .Take(limit)
            .Include(c => c.Address)
            .ToListAsync();
        
        return clients;
    }
    
    public async Task<Client?> UpdateClientAddressAsync(Guid id, Address address)
    {
        var client = await DeleteClientAsync(id);
        if (client is not null)
        {
            client.Address = address;
            client = await CreateClientAsync(client);
        }

        return client;
    }
    
    public async Task<Client?> DeleteClientAsync(Guid id)
    {
        var client = _context.Clients
            .Include(c => c.Address)
            .FirstOrDefault(c => c.Id == id);
        if (client == null)
        {
            throw new ArgumentException($"Invalid request: Client with id {id} does not exists.");
        }
        
        _context.Addresses.Remove(client.Address);
        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
        return client;
    }
}