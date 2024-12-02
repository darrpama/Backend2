using APIV1.Models;
using APIV1.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace APIV1.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<Client> AddClientAsync(Client client)
    {
        await _clientRepository.CreateClientAsync(client);
        return client;
    }

    public async Task<Client> GetClientAsync(string name, string surname)
    {
        var client = await _clientRepository.ReadClientAsync(name, surname);
        if (client == null)
        {
            throw new ArgumentException($"Invalid request: Client with name {name} and surname {surname} does not exists.");
        }
        return client;
    }
    
    public async Task<List<Client>> GetAllClientsAsync(int limit, int offset)
    {
        if (limit < 0 || offset < 0)
        {
            throw new ArgumentException($"Invalid request: Limit {limit}, Offset {offset}.");
        }
        var clients = await _clientRepository.ReadAllClientsAsync(limit, offset);
        return clients;
    }
    
    public async Task<Client> ChangeClientAddressAsync(Guid id, Address address)
    {
        var client = await _clientRepository.UpdateClientAddressAsync(id, address);
        if (client == null)
        {
            throw new ArgumentException($"Invalid request: Client with id {id} does not exists.");
        }
        return client;
    }
    public async Task<Client> DeleteClientAsync(Guid id)
    {
        var client = await _clientRepository.DeleteClientAsync(id);
        if (client == null)
        {
            throw new ArgumentException($"Invalid request: Client with id {id} does not exists.");
        }
        return client;
    }


    
    

}