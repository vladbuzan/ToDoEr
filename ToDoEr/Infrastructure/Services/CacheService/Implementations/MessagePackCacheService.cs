using Infrastructure.Services.CacheService.Interfaces;
using MessagePack;
using Microsoft.Extensions.Caching.Distributed;

namespace Infrastructure.Services.CacheService.Implementations;

public class MessagePackCacheService : ICacheService
{
    private readonly IDistributedCache _cache;
    private const int DefaultExpMinutes = 10;

    public MessagePackCacheService(IDistributedCache cache) => _cache = cache;

    public async Task SetAsync<T>(T entity,
        string key,
        CancellationToken cancellationToken = default
    )
        where T : ICacheEntry
    {
        var serializedEntity = MessagePackSerializer.Serialize(entity,
            cancellationToken: cancellationToken);

        await _cache.SetAsync(key,
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
        var serializedEntity = await _cache.GetAsync(key, cancellationToken);

        if (serializedEntity is null) return default;

        return MessagePackSerializer.Deserialize<T>(serializedEntity,
            cancellationToken: cancellationToken);
    }

    public Task RemoveAsync(string key, CancellationToken cancellationToken = default) =>
        _cache.RemoveAsync(key, cancellationToken);
}