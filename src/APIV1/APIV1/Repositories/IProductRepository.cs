using APIV1.Models;

namespace APIV1.Repositories;

public interface IProductRepository
{
    Task<Product?> CreateProductAsync(Product product);
    Task<Product?> ReadProductAsync(Guid id);
    Task<Product?> UpdateProductAsync(Product product);
    Task<Product?> DeleteProductAsync(Guid id);
    Task<List<Product>> GetAllProductsAsync(int limit, int offset);
}