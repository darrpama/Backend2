using API.Models;

namespace API.Services;

public static class ServiceProviderExtensions
{
    public static void AddClientService(this IServiceCollection services)
    {
        services.AddScoped<ClientService>();
    }
    public static void AddProductService(this IServiceCollection services)
    {
        services.AddScoped<ProductService>();
    }
    public static void AddSupplierService(this IServiceCollection services)
    {
        services.AddScoped<SupplierService>();
    }
    public static void AddAddressService(this IServiceCollection services)
    {
        services.AddScoped<AddressService>();
    }
    public static void AddImageService(this IServiceCollection services)
    {
        services.AddScoped<ImageService>();
    }
}