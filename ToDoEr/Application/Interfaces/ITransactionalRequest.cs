using MediatR;
using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Interfaces;

public interface ITransactionalRequest : IRequest<Unit>
{
    IDbContextTransaction Transaction { get; set; }
}

public interface ITransactionalRequest<out T> : IRequest<T>
{
    IDbContextTransaction Transaction { get; set; }
}