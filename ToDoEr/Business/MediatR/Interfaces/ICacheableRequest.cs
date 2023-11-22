using Business.Models.Base;
using MediatR;

namespace Business.MediatR.Interfaces;

public interface ICacheableRequest<out TEntity> : IRequest<TEntity>
    where TEntity : IBaseDto
{
    public Guid Id { get; set; }
}