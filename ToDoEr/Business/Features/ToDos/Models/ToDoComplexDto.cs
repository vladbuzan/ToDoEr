using Business.Models.Base;
using Data.Entities;

namespace Business.Features.ToDos.Models;

public class ToDoComplexDto : BaseDto<ToDoComplexDto, ToDo>
{
    public required string Description { get; set; }
}