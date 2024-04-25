using Business.Features.Users.Models;
using Business.MediatR.Interfaces;
using Data.Entities;
using Data.Repositories.Interfaces;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage;

namespace Business.Features.Users.Commands;

public class CreateUser
{
    public class Request : ITransactionalRequest<UserSimpleDto>
    {
        public IDbContextTransaction? Transaction { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

    internal class Handler : IRequestHandler<Request, UserSimpleDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserSimpleDto> Handle(Request request,
            CancellationToken cancellationToken
        )
        {
            var user = request.Adapt<User>();
            await _userRepository.AddAsync(user, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return user.Adapt<UserSimpleDto>();
        }
    }
}