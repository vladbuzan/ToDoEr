using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class ToDoErContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<ToDo> ToDos { get; set; } = null!;
    public DbSet<ToDoList> ToDoLists { get; set; } = null!;
    public DbSet<User> Type { get; set; } = null!;
}