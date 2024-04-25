using Data.Context;
using Data.Entities;
using Data.Repositories.Base;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Implementations;

public class ToDoListRepository : BaseRepository<ToDoList>, IToDoListRepository
{
    public ToDoListRepository(ToDoErContext context) : base(context) { }

    public Task<int> GetToDoCountByIdAsync(Guid id, CancellationToken cancellationToken) =>
        DbSet.Where(t => t.Id == id).CountAsync(cancellationToken);
}