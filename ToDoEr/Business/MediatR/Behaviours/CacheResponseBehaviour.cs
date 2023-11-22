using Business.MediatR.Interfaces;
using Business.Models.Base;
using Infrastructure.Services.CacheService.Interfaces;
using Mapster;
using MediatR;

namespace Business.MediatR.Behaviours;

public class CacheResponseBehaviour<TRequest, TResponse, TCache>
    : IPipelineBehavior<TRequest, TResponse>
    where TResponse : IBaseDto
    where TCache : ICacheEntry
    where TRequest : ICacheableRequest<TResponse>
{
    private readonly ICacheService _cache;

    public CacheResponseBehaviour(ICacheService cache) => _cache = cache;

    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        var cachedResponse = await _cache
            .GetAsync<TResponse>(request.Id.ToString(), cancellationToken);

        if (cachedResponse is not null)
            return cachedResponse;

        var result = await next();
        await _cache.SetAsync(result.Adapt<TCache>(), result.Id.ToString(), cancellationToken);

        return result;
    }
}