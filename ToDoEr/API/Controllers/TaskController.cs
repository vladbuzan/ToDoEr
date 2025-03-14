using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/Board/{boardId:guid}/[controller]")]
[ApiController]
public class TaskController : ControllerBase { }