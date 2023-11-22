using Business.MediatR.Interfaces;
using Infrastructure.Services.CacheService.Interfaces;
using MediatR;

namespace Business.MediatR.Behaviours;

public class CacheInvalidateBehaviour<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICacheInvalidateRequest
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