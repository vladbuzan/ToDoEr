using Application.Abstractions.Services.CacheService;
using MessagePack;
using Microsoft.Extensions.Caching.Distributed;

namespace Infrastructure.Services.CacheService.Implementations;

public class MessagePackCacheService(IDistributedCache cache) : ICacheService
{
    private const int DefaultExpMinutes = 10;

    public async Task SetAsync<T>(T entity,
        string key,
        CancellationToken cancellationToken = default
    )
        where T : ICacheEntry
    {
        var serializedEntity = MessagePackSerializer.Serialize(entity,
            cancellationToken: cancellationToken);

        await cache.SetAsync(key,
            serializedEntity,
            new()
            {
                SlidingExpiration = TimeSpan.FromMinutes(DefaultExpMinutes)
            },
            cancellationToken);
    }

    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken)
        where T : ICacheEntry
    {
        var serializedEntity = await cache.GetAsync(key, cancellationToken);

        if (serializedEntity is null) return default;

        return MessagePackSerializer.Deserialize<T>(serializedEntity,
            cancellationToken: cancellationToken);
    }

    public Task RemoveAsync(string key, CancellationToken cancellationToken = default) =>
        cache.RemoveAsync(key, cancellationToken);
}