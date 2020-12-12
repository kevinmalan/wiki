using Wiki.Common.Exceptions;
using Wiki.Common.Responses;
using Wiki.Core.Contexts;
using Wiki.Core.HandlerRequests.Auth;
using Wiki.Core.Services.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Wiki.Core.Services.Handlers
{
    public class SignInHandler : IRequestHandler<SignInHandlerRequest, SignInResponse>
    {
        private readonly IAuthService _authService;
        private readonly DataContext _dataContext;

        public SignInHandler(
            IAuthService authService,
            DataContext dataContext)
        {
            _authService = authService;
            _dataContext = dataContext;
        }

        public async Task<SignInResponse> Handle(SignInHandlerRequest request, CancellationToken cancellationToken)
        {
            var user = await _dataContext.User
                .Include(u => u.UserRole)
                .SingleOrDefaultAsync(u => u.UserName == request.UserName, cancellationToken: cancellationToken);

            if (user is null)
            {
                throw new BadRequest($"No username and / or password match that criteria.");
            }

            var password = await _dataContext.User
                .Where(u => u.UniqueId == user.UniqueId)
                .Select(u => u.Password)
                .FirstAsync(cancellationToken: cancellationToken);

            if (!BCrypt.Net.BCrypt.Verify(request.Password, password))
            {
                throw new BadRequest($"No username and / or password match that criteria.");
            }

            return new SignInResponse
            {
                Jwt = _authService.GenerateJwt(user.UniqueId, user.UserName, user.UserRole.Role)
            };
        }
    }
}