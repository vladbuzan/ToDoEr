using Domain.Interfaces;

namespace Domain.Entities;

public class User : IEntity
{
    public Guid Id { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public List<ToDoList> ToDoLists { get; set; } = new();
}