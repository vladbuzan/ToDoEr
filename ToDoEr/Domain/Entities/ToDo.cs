using Domain.Interfaces;

namespace Domain.Entities;

public class ToDo : IEntity
{
    public Guid Id { get; set; }
    public required string Description { get; set; }
    public ToDoList ToDoList { get; set; } = null!;
}