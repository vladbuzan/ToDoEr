using Application.Models.Base;
using Domain.Entities;

namespace Application.Features.ToDos.Models;

public class ToDoSimpleDto : BaseDto<ToDoSimpleDto, ToDo>
{
    public required string Description { get; set; }
}