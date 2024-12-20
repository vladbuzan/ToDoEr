using Application.Abstractions.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Infrastructure.Repositories;

public class ToDoListRepository(ToDoErContext context)
    : BaseRepository<ToDoList>(context), IToDoListRepository
{
    public Task<int> GetToDoCountByIdAsync(Guid id, CancellationToken cancellationToken) =>
        DbSet.Where(t => t.Id == id).CountAsync(cancellationToken);
}