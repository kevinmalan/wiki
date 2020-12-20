using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Common.Responses;
using Wiki.Core.Handler_Requests.Company;
using Wiki.Core.Services.Contracts;

namespace Wiki.Core.Handlers.Company
{
    public class SignInCompanyHandler : IRequestHandler<SignInCompanyHandlerRequest, SignInResponse>
    {
        private readonly IQueryService _queryService;
        private readonly ITokenService _tokenService;

        public SignInCompanyHandler(
            IQueryService queryService,
            ITokenService tokenService)
        {
            _queryService = queryService;
            _tokenService = tokenService;
        }

        public async Task<SignInResponse> Handle(SignInCompanyHandlerRequest request, CancellationToken cancellationToken)
        {
            var companyRole = await _queryService.GetUserCompanyRoleAsync(request.UniqueUserId, request.UniqueCompanyId, cancellationToken);

            if (companyRole is null)
            {
                throw new UnauthorizedAccessException($"The user has no connection to this company.");
            }

            return new SignInResponse
            {
                Jwt = _tokenService.GenerateJwt(request.UniqueUserId, request.UniqueCompanyId, companyRole.Value)
            };
        }
    }
}