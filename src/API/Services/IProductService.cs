using API.Models;

namespace API.Services;

public interface IProductService
{
    Task<Product> AddProductAsync(Product product);
    Task<Product> DeleteProductAsync(Guid id);
    Task<Product> GetProductAsync(Guid id);
    Task<List<Product>> GetAllProductsAsync();
}