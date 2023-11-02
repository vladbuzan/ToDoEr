using Data.Context;
using Data.Entities;
using Data.Repositories.Base;
using Data.Repositories.Interfaces;

namespace Data.Repositories.Implementations;

public class ToDoListRepository : BaseRepository<ToDoList>, IToDoListRepository
{
    public ToDoListRepository(ToDoErContext context) : base(context) { }
}