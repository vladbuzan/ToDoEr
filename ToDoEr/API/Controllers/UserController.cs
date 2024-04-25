using API.Requests.Users;
using Business.Features.Users.Commands;
using Business.Features.Users.Models;
using Business.Features.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<UserComplexDto>> GetById([FromRoute] Guid id,
        CancellationToken cancellationToken
    )
    {
        var response = await _mediator.Send(new GetUserById.Request
            {
                Id = id
            },
            cancellationToken);

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<UserSimpleDto>> Create([FromForm] CreateUserRequest request,
        CancellationToken cancellationToken
    )
    {
        var response = await _mediator.Send(new CreateUser.Request
            {
                Email = request.Email,
                Password = request.Password
            },
            cancellationToken);

        return Ok(response);
    }
}