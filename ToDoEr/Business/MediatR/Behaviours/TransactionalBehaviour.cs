using Business.MediatR.Interfaces;
using Data.Context;
using Data.Repositories.Interfaces;
using MediatR;

namespace Business.MediatR.Behaviours;

public class TransactionalBehaviour<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ITransactionalRequest<TResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    public TransactionalBehaviour(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        request.Transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken);
        var response = await next();
        await request.Transaction.CommitAsync(cancellationToken);

        return response;
    }
}