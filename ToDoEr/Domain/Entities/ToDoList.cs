﻿using Domain.Interfaces;

namespace Domain.Entities;

public class ToDoList : IEntity
{
    public Guid Id { get; set; }
    public List<ToDo> ToDos { get; set; } = new();
    public User User { get; set; } = null!;
}