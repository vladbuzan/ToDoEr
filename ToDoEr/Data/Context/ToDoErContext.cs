﻿using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class ToDoErContext : DbContext
{
    public ToDoErContext(DbContextOptions options) : base(options) { }

    public DbSet<ToDo> ToDos { get; set; } = null!;
}