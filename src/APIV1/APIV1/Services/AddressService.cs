using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class AddressService
{
    private readonly ApplicationDbContext _context;

    public AddressService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Address> AddAddressAsync(Address address)
    {
        try
        {
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();
            return address;
        }
        catch
        {
            throw;
        }
    }

    public async Task<Address> DeleteAddressAsync(Guid id)
    {
        try
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                throw new ArgumentException($"Invalid request: Address with id {id} does not exists.");
            }
            
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
            return address;
        }
        catch
        {
            throw;
        }
    }

    public async Task<Address> GetAddressAsync(Guid id)
    {
        try
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                throw new ArgumentException($"Invalid request: Address with id {id} does not exists.");
            }
            
            return address;
        }
        catch
        {
            throw;
        }
    }

    public async Task<List<Address>> GetAllAddressesAsync()
    {
        try
        {
            var addresses = await _context.Addresses.ToListAsync();
            if (addresses == null)
            {
                throw new ArgumentException($"Invalid request: Addresses relation does not exists.");
            }
            
            return addresses;
        }
        catch
        {
            throw;
        }
    }

}