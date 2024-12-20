using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ToDoListController(IMediator mediator)
{
    private readonly IMediator _mediator = mediator;
}