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
}