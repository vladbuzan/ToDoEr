using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using StackExchange.Redis.Extensions.Core.Abstractions;
using StackExchange.Redis.Extensions.Core.Implementations;

namespace Infrastructure.Services.Redis.Implementations;

public class Cache
{
    private readonly IRedisClient _redisClient;

    public Cache(IDatabase db) => _db = db;

    public void T()
    {
        _redisClient.
    }
}