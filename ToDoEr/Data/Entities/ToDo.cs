using Data.Interfaces;

namespace Data.Entities;

public class ToDo : IEntity
{
    public Guid Id { get; set; }
    public required string Description { get; set; }
}