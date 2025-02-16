using Domain.Interfaces;

namespace Domain.Entities;

public class Task : IEntity
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    
    public Guid BoardId { get; set; }
    public Board? Board { get; set; }
}