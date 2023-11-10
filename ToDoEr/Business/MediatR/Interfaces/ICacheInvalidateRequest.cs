using MediatR;

namespace Business.MediatR.Interfaces;

public interface ICacheInvalidateRequest : IRequest<Unit>
{
    public Guid Id { get; set; }
}

public interface ICacheInvalidateRequest<out T> : IRequest<T>
{
    public Guid Id { get; set; }
}