using Application.Abstractions.Repositories;
using Application.Features.Board.Models;
using MediatR;

namespace Application.Features.Board.Queries;

public class GetAllBoards
{
    public record Request : IRequest<List<BoardSimpleDto>>;

    internal class Handler(IBoardRepository boardRepository) : IRequestHandler<Request, List<BoardSimpleDto>>
    {
        public Task<List<BoardSimpleDto>> Handle(Request request, CancellationToken cancellationToken) =>
            boardRepository.GetAllAsyncAsNoTracking<BoardSimpleDto>(cancellationToken);
    }
}