using Business.Models.Base;
using Infrastructure.Services.CacheService.Interfaces;
using MediatR;

namespace Business.MediatR.Interfaces;

public interface ICacheableRequest<out TEntity, TCache> : IRequest<TEntity>
    where TCache : ICacheEntry
    where TEntity : IBaseDto
{
    public Guid Id { get; set; }
}