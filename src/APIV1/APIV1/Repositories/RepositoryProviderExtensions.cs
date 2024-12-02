namespace APIV1.Repositories;

public static class RepositoryProviderExtensions
{
    public static void AddClientRepository(this IServiceCollection services)
    {
        services.AddTransient<IClientRepository, PostgresClientRepository>();
    }
    public static void AddProductRepository(this IServiceCollection services)
    {
        services.AddTransient<IProductRepository, PostgresProductRepository>();
    }
    public static void AddImageRepository(this IServiceCollection services)
    {
        services.AddTransient<IImageRepository, PostgresImageRepository>();
    }
}