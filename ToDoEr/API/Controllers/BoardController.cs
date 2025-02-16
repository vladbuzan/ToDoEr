using API.Requests.Board;
using Application.Features.Board.Commands;
using Application.Features.Board.Models;
using Application.Features.Board.Queries;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class BoardController(IMediator mediator)
{
    [HttpPost]
    public async Task<BoardSimpleDto> CreateAsync([FromBody] CreateBoardRequest request,
        CancellationToken cancellationToken
    )
    {
        var board = await mediator.Send(request.Adapt<CreateBoard.Request>(), cancellationToken);

        return board;
    }

    [HttpGet]
    public async Task<List<BoardSimpleDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var boards = await mediator.Send(new GetAllBoards.Request(), cancellationToken);

        return boards;
    }

    [HttpPut("{id:guid}")]
    public async Task<BoardSimpleDto> UpdateAsync([FromRoute] Guid id,
        [FromBody] UpdateBoardRequest request,
        CancellationToken cancellationToken
    )
    {
        var board = await mediator.Send(request.Adapt<UpdateBoard.Request>(), cancellationToken);

        return board;
    }
}