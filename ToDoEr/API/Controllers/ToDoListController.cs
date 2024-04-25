using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ToDoListController
{
    private readonly IMediator _mediator;
    
    public ToDoListController(IMediator mediator) => _mediator = mediator;
    
}