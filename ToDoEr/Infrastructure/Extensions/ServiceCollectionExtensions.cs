using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRedisCache(this IServiceCollection serviceCollection,
        string connectionString
    ) => serviceCollection.AddStackExchangeRedisCache(options => options.ConfigurationOptions =
        new()
        {
            EndPoints =
            {
                connectionString
            }
        });
}