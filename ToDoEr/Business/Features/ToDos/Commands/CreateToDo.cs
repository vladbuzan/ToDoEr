using Business.Features.ToDos.Models;
using Business.MediatR.Interfaces;
using Data.Entities;
using Data.Repositories.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage;

namespace Business.Features.ToDos.Commands;

public class CreateToDo
{
    public class Request : ITransactionalRequest<ToDoComplexDto>
    {
        public IDbContextTransaction? Transaction { get; set; }
        public required string Description { get; set; }
    }

    internal class Handler : IRequestHandler<Request, ToDoComplexDto>
    {
        private readonly IToDoRepository _toDoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IToDoRepository toDoRepository, IUnitOfWork unitOfWork)
        {
            _toDoRepository = toDoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ToDoComplexDto> Handle(Request request, CancellationToken cancellationToken)
        {
            var toDo = request.Adapt<ToDo>();
            await _toDoRepository.AddAsync(toDo, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return toDo.Adapt<ToDoComplexDto>();
        }
    }
}