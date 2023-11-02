using Data.Context;
using Data.Entities;
using Data.Repositories.Base;
using Data.Repositories.Interfaces;

namespace Data.Repositories.Implementations;

public class ToDoRepository : BaseRepository<ToDo>, IToDoRepository
{
    public ToDoRepository(ToDoErContext context) : base(context) { }
}