using Data.Context;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddToDoErDb(this IServiceCollection services, 
        ConfigurationManager configManager, 
        string name)
    {
        var connectionString = configManager.GetConnectionString(name);

        if (string.IsNullOrEmpty(connectionString))
            throw new SetupException("Connection string is not set");
            
        return services
            .AddDbContext<ToDoErContext>(options => options.UseNpgsql(connectionString));
    }
}