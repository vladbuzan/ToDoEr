using System.Linq.Expressions;
using Data.Context;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Base;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : class, IEntity
{
    private readonly ToDoErContext _context;

    protected BaseRepository(ToDoErContext context) => _context = context;

    public Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
        CancellationToken cancellation = default
    ) => _context
        .Set<TEntity>()
        .Select(selector)
        .ToListAsync(cancellation);

    public Task<List<TEntity>> GetAllAsync(CancellationToken cancellation = default) => _context
        .Set<TEntity>()
        .ToListAsync(cancellation);

    public Task<List<TResult>> GetAllAsyncAsNoTracking<TResult>(
        Expression<Func<TEntity, TResult>> selector,
        CancellationToken cancellation = default
    ) => _context
        .Set<TEntity>()
        .AsNoTracking()
        .Select(selector)
        .ToListAsync(cancellation);

    public Task<List<TEntity>> GetAllAsyncAsNoTracking(CancellationToken cancellation = default) =>
        _context
            .Set<TEntity>()
            .AsNoTracking()
            .ToListAsync(cancellation);
}