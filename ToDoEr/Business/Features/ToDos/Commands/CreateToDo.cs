using Business.Features.ToDos.Models;
using Business.MediatR.Interfaces;
using Data.Entities;
using Data.Repositories.Interfaces;
using Infrastructure.Exceptions;
using Infrastructure.Services.CacheService.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage;

namespace Business.Features.ToDos.Commands;

public class CreateToDo
{
    public class Request : ITransactionalRequest<ToDoSimpleDto>
    {
        public IDbContextTransaction? Transaction { get; set; }
        public Guid ToDoListId { get; set; }
        public required string Description { get; set; }
    }

    internal class Handler : IRequestHandler<Request, ToDoSimpleDto>
    {
        private readonly IToDoRepository _toDoRepository;
        private readonly IToDoListRepository _toDoListRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICacheService _cacheService;

        public Handler(IToDoRepository toDoRepository,
            IToDoListRepository toDoListRepository,
            IUnitOfWork unitOfWork,
            ICacheService cacheService
        )
        {
            _toDoRepository = toDoRepository;
            _toDoListRepository = toDoListRepository;
            _unitOfWork = unitOfWork;
            _cacheService = cacheService;
        }

        public async Task<ToDoSimpleDto> Handle(Request request,
            CancellationToken cancellationToken
        )
        {
            var count = await _toDoListRepository
                .GetToDoCountByIdAsync(request.ToDoListId, cancellationToken);

            if (count >= Constants.MaxToDosInList)
                throw new EntityException($"Couldn't create ToDo item, can have at most {
                    Constants.MaxToDosInList} items in a list.");

            var toDoList = await _toDoListRepository
                .GetByIdAsync(request.ToDoListId, cancellationToken);

            var item = new ToDo
            {
                Description = request.Description,
                ToDoList = toDoList
            };

            await _toDoRepository.AddAsync(item, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _cacheService.RemoveAsync(request.ToDoListId.ToString(), cancellationToken);

            return item.Adapt<ToDoSimpleDto>();
        }
    }
}