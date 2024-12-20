using Application.Abstractions.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Infrastructure.Repositories;

public class ToDoRepository(ToDoErContext context) : BaseRepository<ToDo>(context), IToDoRepository;