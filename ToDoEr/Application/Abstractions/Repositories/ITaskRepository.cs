using Task = Domain.Entities.Task;

namespace Application.Abstractions.Repositories;

public interface ITaskRepository : IBaseRepository<Task>;