using Application.Abstractions.UnitOfWork;
using Application.Interfaces;
using MediatR;

namespace Infrastructure.Behaviours;

public class TransactionalBehaviour<TRequest, TResponse>(IUnitOfWork unitOfWork)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ITransactionalRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        request.Transaction = await unitOfWork.BeginTransactionAsync(cancellationToken);
        var response = await next();
        await request.Transaction.CommitAsync(cancellationToken);

        return response;
    }
}