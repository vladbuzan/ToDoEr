using System.Linq.Expressions;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Application.Abstractions.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class, IEntity
{
    public Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
        CancellationToken cancellation = default
    );

    public Task<List<TEntity>> GetAllAsync(CancellationToken cancellation = default);

    public Task<List<TResult>> GetAllAsyncAsNoTracking<TResult>(Expression<Func<TEntity, TResult>> selector,
        CancellationToken cancellation = default
    );

    public Task<List<TEntity>> GetAllAsyncAsNoTracking(CancellationToken cancellation);
    public Task<List<TResult>> GetAllAsyncAsNoTracking<TResult>(CancellationToken cancellation = default);
    public Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellation = default);
    public Task<TResult> GetByIdAsync<TResult>(Guid id, CancellationToken cancellation = default);
    public Task<EntityEntry<TEntity>> AddAsync(TEntity entity, CancellationToken cancellation = default);
    public void Update(TEntity entity, object updateModel);
    public Task<bool> ExistsAsync(Guid id, CancellationToken cancellation = default);
}