using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class ToDoErContext : DbContext
{
    public ToDoErContext(DbContextOptions options) : base(options) { }
}