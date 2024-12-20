using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Abstractions.UnitOfWork;

public interface IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    public int SaveChanges();

    public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
}