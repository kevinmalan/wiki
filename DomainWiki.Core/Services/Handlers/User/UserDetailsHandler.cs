using DomainWiki.Common.Responses;
using DomainWiki.Core.Contexts;
using DomainWiki.Core.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DomainWiki.Core.Services.Handlers.User
{
    public class UserDetailsHandler : IRequestHandler<UserDetailsRequestInternal, UserResponse>
    {
        private readonly DataContext _dataContext;

        public UserDetailsHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<UserResponse> Handle(UserDetailsRequestInternal request, CancellationToken cancellationToken)
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