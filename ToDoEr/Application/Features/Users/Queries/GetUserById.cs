using Application.Abstractions.Repositories;
using Application.Abstractions.Services.CacheService;
using Application.Features.Users.Models;
using MediatR;

namespace Application.Features.Users.Queries;

public class GetUserById
{
    public class Request : IRequest<UserComplexDto>
    {
        public Guid Id { get; set; }
    }

    internal class Handler(IUserRepository userRepository, ICacheService cache)
        : IRequestHandler<Request, UserComplexDto>
    {
        public async Task<UserComplexDto> Handle(Request request,
            CancellationToken cancellationToken
        )
        {
            return await userRepository
                .GetByIdAsync<UserComplexDto>(request.Id, cancellationToken);
        }
    }
}