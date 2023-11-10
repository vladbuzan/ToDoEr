namespace Infrastructure.Services.CacheService.Interfaces;

public interface ICacheService
{
    Task SetAsync<T>(T entity, string key, CancellationToken cancellationToken)
        where T : ICacheEntry;

    Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken);

    Task RemoveAsync(string key, CancellationToken cancellationToken);
}