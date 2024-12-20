using Application.Abstractions.Services.CacheService;
using Application.Models.Base;
using MediatR;

namespace Application.Interfaces;

public interface ICacheableRequest<out TEntity, TCacheEntry> : IRequest<TEntity>
    where TEntity : IBaseDto
    where TCacheEntry: ICacheEntry
{
    public Guid Id { get; set; }
}