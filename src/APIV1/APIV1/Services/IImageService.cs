using API.Models;

namespace API.Services;

public interface IImageService
{
    Task<Image> AddImageAsync(Image image);
    Task<Image> DeleteImageAsync(Guid id);
    Task<Image> GetImageAsync(Guid id);
    Task<List<Image>> GetAllImagesAsync();
}