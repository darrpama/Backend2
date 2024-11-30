using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class ProductService
{
    private readonly ApplicationDbContext _context;

    public ProductService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Product> AddProductAsync(Product product)
    {
        try
        {
            var address = await _context.Addresses.FindAsync(product.SupplierId);
            if (address == null)
            {
                throw new ArgumentException($"Invalid request: Supplier with id {product.SupplierId} does not exists.");
            }
            
            var image = await _context.Images.FindAsync(product.ImageId);
            if (image == null)
            {
                throw new ArgumentException($"Invalid request: Image with id {product.ImageId} does not exists.");
            }
            
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }
        catch
        {
            throw;
        }
    }

    public async Task<Product> DeleteProductAsync(Guid id)
    {
        try
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new ArgumentException($"Invalid request: Product with id {id} does not exists.");
            }
            
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }
        catch
        {
            throw;
        }
    }

    public async Task<Product> GetProductAsync(Guid id)
    {
        try
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                throw new ArgumentException($"Invalid request: Product with id {id} does not exists.");
            }
            
            return product;
        }
        catch
        {
            throw;
        }
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        try
        {
            var products = await _context.Products.ToListAsync();
            if (products == null)
            {
                throw new ArgumentException($"Invalid request: Products relation does not exists.");
            }
            
            return products;
        }
        catch
        {
            throw;
        }
    }
}