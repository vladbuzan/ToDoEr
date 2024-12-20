using System.Linq.Expressions;
using Application.Abstractions.Repositories;
using Domain.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Repositories;

public abstract class BaseRepository<TEntity>(DbContext context) : IBaseRepository<TEntity>
    where TEntity : class, IEntity
{
    protected readonly DbSet<TEntity> DbSet = context.Set<TEntity>();

    public Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
        CancellationToken cancellation = default
    ) => context
        .Set<TEntity>()
        .Select(selector)
        .ToListAsync(cancellation);

    public Task<List<TEntity>> GetAllAsync(CancellationToken cancellation = default) => context
        .Set<TEntity>()
        .ToListAsync(cancellation);

    public Task<List<TResult>> GetAllAsyncAsNoTracking<TResult>(
        Expression<Func<TEntity, TResult>> selector,
        CancellationToken cancellation = default
    ) => context
        .Set<TEntity>()
        .AsNoTracking()
        .Select(selector)
        .ToListAsync(cancellation);

    public Task<List<TEntity>> GetAllAsyncAsNoTracking(CancellationToken cancellation = default) =>
        context
            .Set<TEntity>()
            .AsNoTracking()
            .ToListAsync(cancellation);

    public Task<List<TResult>> GetAllAsyncAsNoTracking<TResult>(CancellationToken cancellation =
        default
    ) => context.Set<TEntity>()
        .AsNoTracking()
        .ProjectToType<TResult>()
        .ToListAsync(cancellation);

    public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellation = default)
    {
        // TODO: Add not found exception
        var entity = await context.Set<TEntity>()
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync(cancellation) ??
            throw new("Not found");

        return entity;
    }

    public async Task<TResult> GetByIdAsync<TResult>(Guid id,
        CancellationToken cancellation = default
    )
    {
        // TODO: Add not found exception
        var entity = await context.Set<TEntity>()
                .Where(e => e.Id == id)
                .ProjectToType<TResult>()
                .FirstOrDefaultAsync(cancellation) ??
            throw new("Not found");

        return entity;
    }

    public async Task<EntityEntry<TEntity>> AddAsync(TEntity entity,
        CancellationToken cancellation = default
    ) => await context.Set<TEntity>().AddAsync(entity, cancellation);
}