using Application.Abstractions.Repositories;
using Application.Abstractions.Services.CacheService;
using Application.Abstractions.UnitOfWork;
using Application.Exceptions;
using Application.Features.ToDos.Models;
using Application.Interfaces;
using Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Features.ToDos.Commands;

public class CreateToDo
{
    public class Request : ITransactionalRequest<ToDoSimpleDto>
    {
        public Guid ToDoListId { get; set; }
        public required string Description { get; set; }
        public IDbContextTransaction Transaction { get; set; }
    }

    internal class Handler(IToDoRepository toDoRepository,
            IToDoListRepository toDoListRepository,
            IUnitOfWork unitOfWork,
            ICacheService cacheService
        )
        : IRequestHandler<Request, ToDoSimpleDto>
    {
        public async Task<ToDoSimpleDto> Handle(Request request,
            CancellationToken cancellationToken
        )
        {
            var count = await toDoListRepository
                .GetToDoCountByIdAsync(request.ToDoListId, cancellationToken);

            if (count >= Constants.MaxToDosInList)
                throw new EntityException($"Couldn't create ToDo item, can have at most {
                    Constants.MaxToDosInList} items in a list.");

            var toDoList = await toDoListRepository
                .GetByIdAsync(request.ToDoListId, cancellationToken);

            var item = new ToDo
            {
                Description = request.Description,
                ToDoList = toDoList
            };

            await toDoRepository.AddAsync(item, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            await cacheService.RemoveAsync(request.ToDoListId.ToString(), cancellationToken);

            return item.Adapt<ToDoSimpleDto>();
        }
    }
}