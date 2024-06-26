﻿using System.Linq.Expressions;
using Data.Context;
using Data.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data.Repositories.Base;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : class, IEntity
{
    private readonly ToDoErContext _context;
    protected readonly DbSet<TEntity> DbSet;
    
    protected BaseRepository(ToDoErContext context)
    {
        _context = context;
        DbSet = context.Set<TEntity>();
    }

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

    public Task<List<TResult>> GetAllAsyncAsNoTracking<TResult>(CancellationToken cancellation =
        default
    ) => _context.Set<TEntity>()
        .AsNoTracking()
        .ProjectToType<TResult>()
        .ToListAsync(cancellation);

    public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellation = default)
    {
        // TODO: Add not found exception
        var entity = await _context.Set<TEntity>()
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
        var entity = await _context.Set<TEntity>()
                .Where(e => e.Id == id)
                .ProjectToType<TResult>()
                .FirstOrDefaultAsync(cancellation) ??
            throw new("Not found");

        return entity;
    }

    public async Task<EntityEntry<TEntity>> AddAsync(TEntity entity,
        CancellationToken cancellation = default
    ) => await _context.Set<TEntity>().AddAsync(entity, cancellation);
}