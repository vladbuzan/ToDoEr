using Application.Abstractions.Repositories;
using Application.Features.Users.Models;
using MediatR;

namespace Application.Features.Users.Queries;

public class GetUsers
{
    public class Request : IRequest<List<UserSimpleDto>> { };

    internal class Handler(IUserRepository userRepository) : IRequestHandler<Request, List<UserSimpleDto>>
    {
        public Task<List<UserSimpleDto>> Handle(Request request,
            CancellationToken cancellationToken
        ) => userRepository.GetAllAsyncAsNoTracking<UserSimpleDto>(cancellationToken);
    }
}