using Business.Models.Base;
using Infrastructure.Services.CacheService.Interfaces;
using MediatR;

namespace Business.MediatR.Interfaces;

public interface ICacheableRequest<out TEntity, TCacheEntry> : IRequest<TEntity>
    where TEntity : IBaseDto
    where TCacheEntry: ICacheEntry
{
    public Guid Id { get; set; }
}