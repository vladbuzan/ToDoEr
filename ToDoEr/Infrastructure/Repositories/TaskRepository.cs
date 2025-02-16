using Application.Abstractions.Repositories;
using Persistence.Context;
using Task = Domain.Entities.Task;

namespace Infrastructure.Repositories;

public class TaskRepository(ToDoErContext context) : BaseRepository<Task>(context), ITaskRepository;