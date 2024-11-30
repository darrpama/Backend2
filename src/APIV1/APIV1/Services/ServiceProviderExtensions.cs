namespace APIV1.Services;

public static class ServiceProviderExtensions
{
    public static void AddClientService(this IServiceCollection services)
    {
        services.AddTransient<IClientService, ClientService>();
    }
    public static void AddProductService(this IServiceCollection services)
    {
        services.AddTransient<IProductService, ProductService>();
    }
}