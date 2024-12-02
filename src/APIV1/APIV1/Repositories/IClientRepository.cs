using APIV1.Models;

namespace APIV1.Repositories;

public interface IClientRepository
{
    Task<Client?> CreateClientAsync(Client client);
    Task<Client?> ReadClientAsync(string name, string surname);
    Task<Client?> ReadClientAsync(Guid id);
    Task<Client?> UpdateClientAddressAsync(Guid id, Address client);
    Task<Client?> DeleteClientAsync(Guid id);
    Task<List<Client>> ReadAllClientsAsync(int limit, int offset);
}