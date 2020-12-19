using Wiki.Common.Exceptions;
using Wiki.Common.Responses;
using Wiki.Core.HandlerRequests.Auth;
using Wiki.Core.Services.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Wiki.Core.Services.Handlers
{
    public class SignInHandler : IRequestHandler<SignInHandlerRequest, SignInResponse>
    {
        private readonly IAuthService _authService;
        private readonly IQueryService _queryService;

        public SignInHandler(
            IAuthService authService,
            IQueryService queryService)
        {
            _authService = authService;
            _queryService = queryService;
        }

        public async Task<SignInResponse> Handle(SignInHandlerRequest request, CancellationToken cancellationToken)
        {
            var user = await _queryService.GetUserAsync(request.UserName, cancellationToken);

            if (user is null)
            {
                throw new BadRequestException($"No username and / or password match that criteria.");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                throw new BadRequestException($"No username and / or password match that criteria.");
            }

            return new SignInResponse
            {
                Jwt = _authService.GenerateJwt(user.UniqueId, user.UserName)
            };
        }
    }
}