using Business.Models.Base;
using Data.Entities;

namespace Business.Features.ToDos.Models;

public class ToDoSimpleDto : BaseDto<ToDoSimpleDto, ToDo>
{
    public required string Description { get; set; }
}