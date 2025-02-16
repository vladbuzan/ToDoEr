using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using Application.Features.Board.Models;
using Application.Interfaces;
using Mapster;
using MediatR;

namespace Application.Features.Board.Commands;

public class UpdateBoard
{
    public record Request(Guid Id, string Name, string Description) : ITransactionalRequest<BoardSimpleDto>,
        ICacheInvalidateRequest<BoardSimpleDto>;

    internal class Handler(IUnitOfWork unitOfWork, IBoardRepository boardRepository)
        : IRequestHandler<Request, BoardSimpleDto>
    {
        public async Task<BoardSimpleDto> Handle(Request request, CancellationToken cancellationToken)
        {
            var board = await boardRepository.GetByIdAsync(request.Id, cancellationToken);
            boardRepository.Update(board, request);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return board.Adapt<BoardSimpleDto>();
        }
    }
}