using API.Requests.Users;
using Application.Features.Users.Commands;
using Application.Features.Users.Models;
using Application.Features.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<UserComplexDto>> GetById([FromRoute] Guid id,
        CancellationToken cancellationToken
    )
    {
        var response = await mediator.Send(new GetUserById.Request
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
        var response = await mediator.Send(new CreateUser.Request
            {
                Email = request.Email,
                Password = request.Password
            },
            cancellationToken);

        return Ok(response);
    }
}