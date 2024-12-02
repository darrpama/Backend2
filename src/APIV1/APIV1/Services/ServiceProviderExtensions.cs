namespace APIV1.Services;

public static class RepositoryProviderExtensions
{
    public static void AddClientRepository(this IServiceCollection services)
    {
        services.AddTransient<IClientRepository, ClientService>();
    }
    public static void AddProductRepository(this IServiceCollection services)
    {
        services.AddTransient<IProductRepository, ProductService>();
    }
}