using APIV1.Models;
using Microsoft.EntityFrameworkCore;

namespace APIV1.Repositories;

public class SupplierRepository : ISupplierRepository
{
    private readonly ApplicationDbContext _context;

    public SupplierRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Supplier> AddSupplierAsync(Supplier supplier)
    {
        try
        {
            await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }
        catch
        {
            throw;
        }
    }

    public async Task<Supplier> DeleteSupplierAsync(Guid id)
    {
        try
        {
            var supplier = _context.Suppliers
                .Include(c => c.Address)
                .FirstOrDefault(c => c.Id == id);
            
            if (supplier == null)
            {
                throw new ArgumentException($"Invalid request: Supplier with id {id} does not exists.");
            }
            
            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }
        catch
        {
            throw;
        }
    }

    public async Task<Supplier> GetSupplierAsync(Guid id)
    {
        try
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                throw new ArgumentException($"Invalid request: Supplier with id {id} does not exists.");
            }
            
            return supplier;
        }
        catch
        {
            throw;
        }
    }

    public async Task<List<Supplier>> GetAllSuppliersAsync()
    {
        try
        {
            var suppliers = await _context.Suppliers.ToListAsync();
            if (suppliers == null)
            {
                throw new ArgumentException($"Invalid request: Suppliers relation does not exists.");
            }
            
            return suppliers;
        }
        catch
        {
            throw;
        }
    }
   
    
    public async Task<Supplier> ChangeSupplierAddressAsync(Guid id, Address address)
    {
        try
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                throw new ArgumentException($"Invalid request: Client with id {id} does not exists.");
            }
            
            var lastAddress = await _context.Addresses.FindAsync(supplier.Address.Id);
            
            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
            
            
            supplier.Address = address;
            await _context.SaveChangesAsync();
            return supplier;
        }
        catch
        {
            throw;
        }
    }
}