namespace APIV1.Repositories;

public static class ServiceProviderExtensions
{
    public static void AddClientService(this IServiceCollection services)
    {
        services.AddTransient<IClientRepository, PostgresClientRepository>();
    }
    public static void AddProductService(this IServiceCollection services)
    {
        services.AddTransient<IProductRepository, PostgresProductRepository>();
    }
}