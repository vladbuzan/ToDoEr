using System.Linq.Expressions;
using Data.Interfaces;

namespace Data.Repositories.Base;

public interface IBaseRepository<TEntity> where TEntity : class, IEntity
{
    public Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
        CancellationToken cancellation
    );

    public Task<List<TEntity>> GetAllAsync(CancellationToken cancellation);

    public Task<List<TResult>> GetAllAsyncAsNoTracking<TResult>(
        Expression<Func<TEntity, TResult>> selector,
        CancellationToken cancellation
    );

    public Task<List<TEntity>> GetAllAsyncAsNoTracking(CancellationToken cancellation);

    public Task<List<TResult>> GetAllAsyncAsNoTracking<TResult>(CancellationToken cancellation);

    public Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellation);
    
    public Task<TResult> GetByIdAsync<TResult>(Guid id, CancellationToken cancellation);
}