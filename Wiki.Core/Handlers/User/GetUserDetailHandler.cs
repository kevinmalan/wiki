using Wiki.Common.Responses;
using Wiki.Core.Requests;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Core.Services.Contracts;

namespace Wiki.Core.Services.Handlers.User
{
    public class GetUserDetailHandler : IRequestHandler<GetUserDetailHandlerRequest, UserResponse>
    {
        private readonly IQueryService _queryService;

        public GetUserDetailHandler(IQueryService queryService)
        {
            _queryService = queryService;
        }

        public async Task<UserResponse> Handle(GetUserDetailHandlerRequest request, CancellationToken cancellationToken)
        {
            var user = await _queryService.GetUserAndRoleAsync(request.Username, cancellationToken);

            return user is null ? null : new UserResponse
            {
                UniqueId = user.UniqueId,
                UserName = user.UserName,
                Role = user.UserRole.Role
            };
        }
    }
}