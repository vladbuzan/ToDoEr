﻿using Domain.Interfaces;

namespace Domain.Entities;

public class Board : IEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public List<Task> Tasks { get; set; } = [];
}