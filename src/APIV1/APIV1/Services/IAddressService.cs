using APIV1.Models;

namespace APIV1.Services;

public interface IAddressService
{
    public Task<Address> AddAddressAsync(Address address);
    public Task<Address> DeleteAddressAsync(Guid id);
    public Task<Address> GetAddressAsync(Guid id);
    public Task<List<Address>> GetAllAddressesAsync();
}