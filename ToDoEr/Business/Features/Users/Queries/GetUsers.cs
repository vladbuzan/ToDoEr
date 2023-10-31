using Business.Features.Users.Models;
using MediatR;

namespace Business.Features.Users.Queries;

public class GetUsers
{
    public class Request : IRequest<List<UserSimpleDto>> { };

    public class Handler : IRequestHandler<Request, List<UserSimpleDto>>
    {
        public Task<List<UserSimpleDto>> Handle(Request request,
            CancellationToken cancellationToken
        ) => throw new NotImplementedException();
    }
}