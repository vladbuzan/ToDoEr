using Business.Models.Base;
using Data.Context;
using Data.Repositories.Implementations;
using Data.Repositories.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddToDoErDb(this IServiceCollection services,
        string connectionString
    ) => services
        .AddDbContext<ToDoErContext>(options =>
            options.UseNpgsql(connectionString));

    public static IServiceCollection AddMapster(this IServiceCollection services)
    {
        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        var assembly = typeof(BaseDto<,>).Assembly;
        typeAdapterConfig.Scan(assembly);

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services) => services
        .AddScoped<IUserRepository, UserRepository>()
        .AddScoped<IUnitOfWork, UnitOfWork>();
}