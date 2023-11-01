using Data.Context;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace Data.Repositories.Implementations;

public class UnitOfWork : IUnitOfWork
{
    private readonly ToDoErContext _context;
    
    public UnitOfWork(ToDoErContext context) => _context = context;

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        _context.SaveChangesAsync(cancellationToken);

    public int SaveChanges() => _context.SaveChanges();

    public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken =
        default
    ) => _context.Database.BeginTransactionAsync(cancellationToken);
}