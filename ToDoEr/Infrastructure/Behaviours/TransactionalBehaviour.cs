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
        await unitOfWork.BeginTransactionAsync(cancellationToken);

        try
        {
            var response = await next();
            await unitOfWork.CommitTransactionAsync(cancellationToken);

            return response;
        }
        catch
        {
            await unitOfWork.RollbackTransactionAsync(cancellationToken);

            throw;
        }
    }
}