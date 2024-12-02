using APIV1.Models;
using Microsoft.EntityFrameworkCore;

namespace APIV1.Repositories;

public class PostgresImageRepository : IImageRepository
{
    private readonly ApplicationDbContext _context;

    public PostgresImageRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Image?> CreateImageAsync(Image image)
    {
        await _context.Images.AddAsync(image);
        await _context.SaveChangesAsync();
        return image;
    }

    public async Task<Image> ReadImageAsync(Guid id)
    {
        var image = await _context.Images.FindAsync(id);
        if (image == null)
        {
            throw new ArgumentException($"Invalid request: Image with id {id} does not exists.");
        }
        
        return image;
    }
    
    public async Task<Image?> UpdateImageAsync(Image image)
    {
        var imageState = await DeleteImageAsync(image.Id);
        if (imageState is not null)
        {
            imageState = await CreateImageAsync(image);
        }

        return imageState;
    }
    
    public async Task<Image?> DeleteImageAsync(Guid id)
    {
        var image = await _context.Images.FindAsync(id);
        if (image == null)
        {
            throw new ArgumentException($"Invalid request: Image with id {id} does not exists.");
        }
        
        _context.Images.Remove(image);
        await _context.SaveChangesAsync();
        return image;
    }
}