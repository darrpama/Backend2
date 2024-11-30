using API.Models;

namespace API.Services;

public interface ISupplierService
{
    Task<Supplier> AddSupplierAsync(Supplier supplier);
    Task<Supplier> DeleteSupplierAsync(Guid id);
    Task<Supplier> GetSupplierAsync(Guid id);
    Task<List<Supplier>> GetAllSuppliersAsync();
}