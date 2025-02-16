using Application.Abstractions.UnitOfWork;
using Microsoft.EntityFrameworkCore.Storage;
using Persistence.Context;

namespace Infrastructure.Repositories;

public class UnitOfWork(ToDoErContext context) : IUnitOfWork
{
    private IDbContextTransaction? _transaction = null;

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        context.SaveChangesAsync(cancellationToken);

    public int SaveChanges() => context.SaveChanges();

    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        _transaction = await context.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken)
    {
        if (_transaction is not null)
            await _transaction.RollbackAsync(cancellationToken);
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction is not null)
            await _transaction.CommitAsync(cancellationToken);
    }
}