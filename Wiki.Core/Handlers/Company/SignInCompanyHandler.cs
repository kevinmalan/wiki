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

        public async Task<SignInResponse> Handle(SignInCompanyHandlerRequest request, CancellationToken cancellationToken)
        {
            var companyRole = await _queryService.GetUserCompanyRoleAsync(request.UserId, request.CompanyId, cancellationToken);

            if (companyRole is null)
            {
                throw new UnauthorizedAccessException($"The user has no connection to this company.");
            }

            await CreateCompanySignInHistoryAsync(request.UserId, request.CompanyId);

            return new SignInResponse
            {
                Jwt = _tokenService.GenerateJwt(request.UserId, request.CompanyId, companyRole.Value)
            };
        }

        private async Task CreateCompanySignInHistoryAsync(Guid userId, Guid companyId)
        {
            await _mediator.Send(new CreateCompanySignInHistoryHandlerRequest
            {
                UserId = userId,
                CompanyId = companyId
            });
        }
    }
}