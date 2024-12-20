using Application.Abstractions.Services.CacheService;
using Application.Interfaces;
using MediatR;

namespace Infrastructure.Behaviours;

public class CacheInvalidateBehaviour<TRequest, TResponse>(ICacheService cache)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICacheInvalidateRequest
{
    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        var result = await next();
        await cache.RemoveAsync(request.Id.ToString(), cancellationToken);

        return result;
    }
}