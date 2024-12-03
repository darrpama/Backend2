namespace APIV1.Services;

public static class ServiceProviderExtensions
{
    public static void AddClientService(this IServiceCollection services)
    {
        services.AddTransient<IClientService, ClientService>();
    }
    public static void AddSupplierService(this IServiceCollection services)
    {
        services.AddTransient<ISupplierService, SupplierService>();
    }
    public static void AddProductService(this IServiceCollection services)
    {
        services.AddTransient<IProductService, ProductService>();
    }
    public static void AddImageService(this IServiceCollection services)
    {
        services.AddTransient<IImageService, ImageService>();
    }
}