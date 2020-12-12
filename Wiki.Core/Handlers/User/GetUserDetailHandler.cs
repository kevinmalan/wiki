using Wiki.Common.Responses;
using Wiki.Core.Contexts;
using Wiki.Core.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Wiki.Core.Services.Handlers.User
{
    public class GetUserDetailHandler : IRequestHandler<GetUserDetailHandlerRequest, UserResponse>
    {
        private readonly DataContext _dataContext;

        public GetUserDetailHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<UserResponse> Handle(GetUserDetailHandlerRequest request, CancellationToken cancellationToken)
        {
            var user = await _dataContext.User
                .Include(u => u.UserRole)
                .SingleOrDefaultAsync(u => u.UserName == request.Username, cancellationToken: cancellationToken);

            return user is null ? null : new UserResponse
            {
                UniqueId = user.UniqueId,
                UserName = user.UserName,
                Role = user.UserRole.Role
            };
        }
    }
}