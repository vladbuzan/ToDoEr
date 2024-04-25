using Business.Features.ToDoLists.Models;
using Business.MediatR.Interfaces;
using Data.Entities;
using Data.Repositories.Interfaces;
using Infrastructure.Exceptions;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage;

namespace Business.Features.ToDoLists.Commands;

public class CreateToDoList
{
    public class Request : ITransactionalRequest<ToDoListSimpleDto>
    {
        public IDbContextTransaction? Transaction { get; set; }
        public Guid UserId { get; set; }
    }

    internal class Handler : IRequestHandler<Request, ToDoListSimpleDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IToDoListRepository _toDoListRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            IToDoListRepository toDoListRepository
        )
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _toDoListRepository = toDoListRepository;
        }

        public async Task<ToDoListSimpleDto> Handle(Request request,
            CancellationToken cancellationToken
        )
        {
            var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken) ??
                throw new EntityException("Couldn't find user with the provided id.");

            var list = new ToDoList
            {
                User = user
            };

            await _toDoListRepository.AddAsync(list, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return list.Adapt<ToDoListSimpleDto>();
        }
    }
}