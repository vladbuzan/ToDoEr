using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using Application.Features.Board.Models;
using Application.Interfaces;
using Mapster;
using MediatR;

namespace Application.Features.Board.Commands;

public class CreateBoard
{
    public record Request(string Name, string Description) : ITransactionalRequest<BoardSimpleDto>;

    internal class Handler(IUnitOfWork unitOfWork, IBoardRepository boardRepository)
        : IRequestHandler<Request, BoardSimpleDto>
    {
        public async Task<BoardSimpleDto> Handle(Request request,
            CancellationToken cancellationToken
        )
        {
            var boardEntity = request.Adapt<Domain.Entities.Board>();
            await boardRepository.AddAsync(boardEntity, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return boardEntity.Adapt<BoardSimpleDto>();
        }
    }
}