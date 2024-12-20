using Application.Abstractions.Repositories;
using Application.Abstractions.UnitOfWork;
using Application.Features.Users.Models;
using Application.Interfaces;
using Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Features.Users.Commands;

public class CreateUser
{
    public class Request : ITransactionalRequest<UserSimpleDto>
    {
        public IDbContextTransaction? Transaction { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

    internal class Handler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<Request, UserSimpleDto>
    {
        public async Task<UserSimpleDto> Handle(Request request,
            CancellationToken cancellationToken
        )
        {
            var user = request.Adapt<User>();
            await userRepository.AddAsync(user, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return user.Adapt<UserSimpleDto>();
        }
    }
}