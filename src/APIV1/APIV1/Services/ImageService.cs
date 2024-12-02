using APIV1.Models;
using APIV1.Repositories;
using Microsoft.EntityFrameworkCore;

namespace APIV1.Services;

public class ImageService : IImageService
{
    private readonly IImageRepository _imageRepository;

    public ImageService(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }
    
    public async Task<Image> AddImageAsync(Image image)
    {
        await _imageRepository.CreateImageAsync(image);
        return image;
    }

    public async Task<Image> GetImageAsync(Guid id)
    {
        var image = await _imageRepository.ReadImageAsync(id);
        if (image == null)
        {
            throw new ArgumentException($"Invalid request: Image with id {id} does not exists.");
        }
        return image;
    }

    public async Task<Image> UpdateImageAsync(Image image)
    {
        var imageState = await _imageRepository.UpdateImageAsync(image);
        if (imageState == null)
        {
            throw new ArgumentException($"Invalid request: Image with id {image.Id} does not exists.");
        }
        
        return imageState;
    }
    
    public async Task<Image> DeleteImageAsync(Guid id)
    {
        var image = await _imageRepository.DeleteImageAsync(id);
        if (image == null)
        {
            throw new ArgumentException($"Invalid request: Image with id {id} does not exists.");
        }
        return image;
    }

}