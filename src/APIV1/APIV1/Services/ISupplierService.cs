using APIV1.Models;

namespace APIV1.Repositories;

public interface ISupplierRepository
{
    Task<Supplier> AddSupplierAsync(Supplier supplier);
    Task<Supplier> DeleteSupplierAsync(Guid id);
    Task<Supplier> GetSupplierAsync(Guid id);
    Task<List<Supplier>> GetAllSuppliersAsync();
    Task<Supplier> ChangeSupplierAddressAsync(Guid id, Address address);
}