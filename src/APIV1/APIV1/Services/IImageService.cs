using APIV1.Models;

namespace APIV1.Repositories;

public interface IImageRepository
{
    Task<Image> AddImageAsync(Image image);
    Task<Image> DeleteImageAsync(Guid id);
    Task<Image> GetImageAsync(Guid id);
    Task<List<Image>> GetAllImagesAsync();
}