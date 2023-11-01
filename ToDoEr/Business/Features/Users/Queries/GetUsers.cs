using Business.Features.Users.Models;
using Data.Repositories.Interfaces;
using MediatR;

namespace Business.Features.Users.Queries;

public class GetUsers
{
    public class Request : IRequest<List<UserSimpleDto>> { };

    public class Handler : IRequestHandler<Request, List<UserSimpleDto>>
    {
        private readonly IUserRepository _userRepository;

        public Handler(IUserRepository userRepository) => _userRepository = userRepository;

        public Task<List<UserSimpleDto>> Handle(Request request,
            CancellationToken cancellationToken
        ) => _userRepository.GetAllAsyncAsNoTracking<UserSimpleDto>(cancellationToken);
    }
}