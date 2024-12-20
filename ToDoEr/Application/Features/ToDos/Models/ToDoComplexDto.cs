using Application.Models.Base;
using Domain.Entities;

namespace Application.Features.ToDos.Models;

public class ToDoComplexDto : BaseDto<ToDoComplexDto, ToDo>
{
    public required string Description { get; set; }
}