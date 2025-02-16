using Application.Features.Task.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/Board/{boardId:guid}/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    public async Task<TaskSimpleDto> CreateTask([FromRoute] Guid boardId, CancellationToken cancellationToken)
    {
        
    }
}