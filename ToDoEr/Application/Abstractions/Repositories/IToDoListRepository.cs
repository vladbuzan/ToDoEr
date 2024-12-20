using Domain.Entities;

namespace Application.Abstractions.Repositories;

public interface IToDoListRepository : IBaseRepository<ToDoList>
{
    public Task<int> GetToDoCountByIdAsync(Guid id, CancellationToken cancellationToken);
}