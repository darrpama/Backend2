using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class ImageService
{
    private readonly ApplicationDbContext _context;

    public ImageService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Image> AddImageAsync(Image image)
    {
        try
        {
            await _context.Images.AddAsync(image);
            await _context.SaveChangesAsync();
            return image;
        }
        catch
        {
            throw;
        }
    }

    public async Task<Image> DeleteImageAsync(Guid id)
    {
        try
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
        catch
        {
            throw;
        }
    }

    public async Task<Image> GetImageAsync(Guid id)
    {
        try
        {
            var image = await _context.Images.FindAsync(id);
            if (image == null)
            {
                throw new ArgumentException($"Invalid request: Image with id {id} does not exists.");
            }
            
            return image;
        }
        catch
        {
            throw;
        }
    }

    public async Task<List<Image>> GetAllImagesAsync()
    {
        try
        {
            var images = await _context.Images.ToListAsync();
            if (images == null)
            {
                throw new ArgumentException($"Invalid request: Images relation does not exists.");
            }
            
            return images;
        }
        catch
        {
            throw;
        }
    }

}