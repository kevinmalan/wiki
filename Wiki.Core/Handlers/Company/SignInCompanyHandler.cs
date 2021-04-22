using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Common.Responses;
using Wiki.Core.Handler_Requests.Company;
using Wiki.Core.Services.Contracts;

namespace Wiki.Core.Handlers.Company
{
    public class SignInCompanyHandler : IRequestHandler<SignInCompanyHandlerRequest, CompanySignInResponse>
    {
        private readonly IMediator _mediator;
        private readonly IQueryService _queryService;
        private readonly ITokenService _tokenService;

        public SignInCompanyHandler(
            IMediator mediator,
            IQueryService queryService,
            ITokenService tokenService)
        {
            _mediator = mediator;
            _queryService = queryService;
            _tokenService = tokenService;
        }

        public async Task<CompanySignInResponse> Handle(SignInCompanyHandlerRequest request, CancellationToken cancellationToken)
        {
            var userId = await _queryService.GetUserIdAsync(request.UniqueUserId);
            var companyId = await _queryService.GetCompanyIdAsync(request.UniqueCompanyId);

            var companyRole = await _queryService.GetUserCompanyRoleAsync(userId, companyId, cancellationToken);

            if (companyRole is null)
            {
                throw new UnauthorizedAccessException($"User with uniqueId '{request.UniqueUserId}' has no connection to company with uniqueId '{request.UniqueCompanyId}'");
            }

            await CreateCompanySignInHistoryAsync(userId, companyId);

            return new CompanySignInResponse
            {
                Jwt = _tokenService.GenerateJwt(request.UniqueUserId, request.UniqueCompanyId, companyRole.Value)
            };
        }

        private async Task CreateCompanySignInHistoryAsync(int userId, int companyId)
        {
            await _mediator.Send(new CreateCompanySignInHistoryHandlerRequest
            {
                UserId = userId,
                CompanyId = companyId
            });
        }
    }
}