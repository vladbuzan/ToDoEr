using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddToDoErDb(
        this IServiceCollection services,
        string connectionString
    ) => services
        .AddDbContext<ToDoErContext>(options =>
            options.UseNpgsql(connectionString));
}