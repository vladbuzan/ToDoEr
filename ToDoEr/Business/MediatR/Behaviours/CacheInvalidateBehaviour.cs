using Business.MediatR.Interfaces;
using Infrastructure.Services.CacheService.Interfaces;
using MediatR;
using ICacheEntry = Microsoft.Extensions.Caching.Memory.ICacheEntry;

namespace Business.MediatR.Behaviours;

public class CacheInvalidateBehaviour<TRequest, TResponse, TCache>
    : IPipelineBehavior<TRequest, TResponse>
    where TCache : ICacheEntry
    where TRequest : ICacheInvalidateRequest<TResponse>
{
    private readonly ICacheService _cache;

    public CacheInvalidateBehaviour(ICacheService cache) => _cache = cache;

    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        var result = await next();
        await _cache.RemoveAsync(request.Id.ToString(), cancellationToken);

        return result;
    }
}