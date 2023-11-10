using Business.MediatR.Behaviours;
using Business.MediatR.Interfaces;
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

    public static IServiceCollection AddMediatR(this IServiceCollection services) =>
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<ITransactionalRequest>();
            cfg.AddOpenBehavior(typeof(TransactionalBehaviour<,>));
            cfg.AddOpenBehavior(typeof(CacheResponseBehaviour<,,>));
        });

    public static IServiceCollection AddMapster(this IServiceCollection services)
    {
        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        var assembly = typeof(BaseDto<,>).Assembly;
        typeAdapterConfig.Scan(assembly);

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services) => services
        .AddScoped<IUserRepository, UserRepository>()
        .AddScoped<IToDoRepository, ToDoRepository>()
        .AddScoped<IToDoListRepository, ToDoListRepository>()
        .AddScoped<IUnitOfWork, UnitOfWork>();
}