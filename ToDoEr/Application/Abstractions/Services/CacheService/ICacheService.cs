﻿namespace Application.Abstractions.Services.CacheService;

public interface ICacheService
{
    Task SetAsync<T>(T entity, string key, CancellationToken cancellationToken) 
        where T : ICacheEntry;

    Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken)
        where T : ICacheEntry;

    Task RemoveAsync(string key, CancellationToken cancellationToken);
}