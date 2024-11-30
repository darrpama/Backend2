using APIV1.Models;
using Microsoft.EntityFrameworkCore;

namespace APIV1.Services;

public class SupplierService : ISupplierService
{
    private readonly ApplicationDbContext _context;

    public SupplierService(ApplicationDbContext context)
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
            var supplier = await _context.Suppliers.FindAsync(id);
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
}