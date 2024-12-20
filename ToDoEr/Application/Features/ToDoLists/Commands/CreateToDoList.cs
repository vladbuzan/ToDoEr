using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using Application.Exceptions;
using Application.Features.ToDoLists.Models;
using Application.Interfaces;
using Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Features.ToDoLists.Commands;

public class CreateToDoList
{
    public class Request : ITransactionalRequest<ToDoListSimpleDto>
    {
        public IDbContextTransaction? Transaction { get; set; }
        public Guid UserId { get; set; }
    }

    internal class Handler(IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IToDoListRepository toDoListRepository
    )
        : IRequestHandler<Request, ToDoListSimpleDto>
    {
        public async Task<ToDoListSimpleDto> Handle(Request request,
            CancellationToken cancellationToken
        )
        {
            var user = await userRepository.GetByIdAsync(request.UserId, cancellationToken) ??
                throw new EntityException("Couldn't find user with the provided id.");

            var list = new ToDoList
            {
                User = user
            };

            await toDoListRepository.AddAsync(list, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return list.Adapt<ToDoListSimpleDto>();
        }
    }
}