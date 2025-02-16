using Application.Abstractions.Repositories;
using Application.Abstractions.Services.CacheService;
using Application.Abstractions.UnitOfWork;
using Application.Features.Task.Models;
using Application.Interfaces;
using Mapster;
using MediatR;

namespace Application.Features.Task.Commands;

public class CreateTask
{
    public class Request : ITransactionalRequest<TaskSimpleDto>
    {
        public Guid BoardId { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
    }

    internal class Handler(IBoardRepository boardRepository,
        ITaskRepository taskRepository,
        IUnitOfWork unitOfWork,
        ICacheService cacheService
    )
        : IRequestHandler<Request, TaskSimpleDto>
    {
        public async Task<TaskSimpleDto> Handle(Request request,
            CancellationToken cancellationToken
        )
        {
            //todo: use proper exceptions
            if (!await boardRepository.ExistsAsync(request.BoardId, cancellationToken))
                throw new Exception("Board doesn't exists!");

            var task = request.Adapt<Domain.Entities.Task>();
            await taskRepository.AddAsync(task, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            await cacheService.RemoveAsync(request.BoardId.ToString(), cancellationToken);

            return task.Adapt<TaskSimpleDto>();
        }
    }
}