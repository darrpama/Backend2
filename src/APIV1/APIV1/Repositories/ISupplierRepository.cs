using APIV1.Models;

namespace APIV1.Repositories;

public interface ISupplierRepository
{
    Task<Supplier?> CreateSupplierAsync(Supplier supplier);
    Task<Supplier?> ReadSupplierAsync(Guid id);
    Task<Supplier?> UpdateSupplierAsync(Supplier supplier);
    Task<Supplier?> UpdateSupplierAddressAsync(Guid id, Address address);
    Task<Supplier?> DeleteSupplierAsync(Guid id);
    Task<List<Supplier?>> GetAllSuppliersAsync();
}