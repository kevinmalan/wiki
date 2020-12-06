using DomainWiki.Common.Exceptions;
using DomainWiki.Common.Responses;
using DomainWiki.Core.Contexts;
using DomainWiki.Core.Requests;
using DomainWiki.Core.Services.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DomainWiki.Core.Services.Handlers
{
    public class UserLoginHandler : IRequestHandler<UserLoginRequestInternal, LoginResponse>
    {
        private readonly IAuthService authService;
        private readonly DataContext dataContext;

        public UserLoginHandler(
            IAuthService authService,
            DataContext dataContext)
        {
            this.authService = authService;
            this.dataContext = dataContext;
        }

        public async Task<LoginResponse> Handle(UserLoginRequestInternal request, CancellationToken cancellationToken)
        {
            var user = await dataContext.User
                .Include(u => u.UserRole)
                .SingleOrDefaultAsync(u => u.UserName == request.UserName, cancellationToken: cancellationToken);

            if (user is null)
            {
                throw new BadRequest($"No username and / or password match that criteria.");
            }

            var password = await dataContext.User
                .Where(u => u.UniqueId == user.UniqueId)
                .Select(u => u.Password)
                .FirstAsync(cancellationToken: cancellationToken);

            if (!BCrypt.Net.BCrypt.Verify(request.Password, password))
            {
                throw new BadRequest($"No username and / or password match that criteria.");
            }

            return new LoginResponse
            {
                Jwt = authService.GenerateJwt(user.UniqueId, user.UserName, user.UserRole.Role)
            };
        }
    }
}