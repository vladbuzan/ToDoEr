using Business.Features.Users.Models;
using Business.MediatR.Interfaces;
using Data.Repositories.Interfaces;
using Infrastructure.Services.CacheService.Interfaces;
using Infrastructure.Services.CacheService.Models;
using Mapster;
using MediatR;

namespace Business.Features.Users.Queries;

public class GetUserById
{
    public class Request : ICacheableRequest<UserComplexDto, UserCacheEntry>
    {
        public Guid Id { get; set; }
    }

    internal class Handler : IRequestHandler<Request, UserComplexDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICacheService _cache;

        public Handler(IUserRepository userRepository, ICacheService cache)
        {
            _userRepository = userRepository;
            _cache = cache;
        }

        public async Task<UserComplexDto> Handle(Request request,
            CancellationToken cancellationToken
        )
        {
            var user = await _cache
                .GetAsync<UserCacheEntry>(request.Id.ToString(), cancellationToken);

            if (user is not null)
                return user.Adapt<UserComplexDto>();

            return await _userRepository
                .GetByIdAsync<UserComplexDto>(request.Id, cancellationToken);
        }
    }
}