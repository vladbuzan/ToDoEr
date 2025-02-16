using MediatR;
using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Interfaces;

public interface ITransactionalRequest : IRequest<Unit>;

public interface ITransactionalRequest<out T> : IRequest<T>;