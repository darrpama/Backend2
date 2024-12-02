using APIV1.Models;

namespace APIV1.Repositories;

public interface IImageRepository
{
    Task<Image?> CreateImageAsync(Image image);
    Task<Image?> ReadImageAsync(Guid id);
    Task<Image?> UpdateImageAsync(Image image);
    Task<Image?> DeleteImageAsync(Guid id);
}