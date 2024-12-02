using APIV1.Models;

namespace APIV1.Repositories;

public interface IClientRepository
{
    Task<Client> AddClientAsync(Client client);
    Task<Client> DeleteClientAsync(Guid id);
    Task<Client> GetClientAsync(string name, string surname);
    Task<List<Client>> GetAllClientsAsync(int limit, int offset);
    Task<Client> ChangeClientAddressAsync(Guid id, Address address);
}