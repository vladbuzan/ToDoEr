using Application.Abstractions.UnitOfWork;
using Microsoft.EntityFrameworkCore.Storage;
using Persistence.Context;

namespace Infrastructure.Repositories;

public class UnitOfWork(ToDoErContext context) : IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        context.SaveChangesAsync(cancellationToken);

    public int SaveChanges() => context.SaveChanges();

    public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken =
        default
    ) => context.Database.BeginTransactionAsync(cancellationToken);
}