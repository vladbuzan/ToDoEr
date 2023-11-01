using Business.Features.Users.Models;
using Data.Repositories.Interfaces;
using MediatR;

namespace Business.Features.Users.Queries;

public class GetUserById
{
    public class Request : IRequest<UserComplexDto>
    {
        public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Request, UserComplexDto>
    {
        private readonly IUserRepository _userRepository;

        public Handler(IUserRepository userRepository) => _userRepository = userRepository;

        public Task<UserComplexDto> Handle(Request request, CancellationToken cancellationToken) =>
            _userRepository.GetByIdAsync<UserComplexDto>(request.Id, cancellationToken);
    }
}