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
            var companyRole = await _queryService.GetUserCompanyRoleAsync(request.UniqueUserId, request.UniqueCompanyId, cancellationToken);

            if (companyRole is null)
            {
                throw new UnauthorizedAccessException($"The user has no connection to this company.");
            }

            await CreateCompanySignInHistoryAsync(request.UniqueUserId, request.UniqueCompanyId);

            return new SignInResponse
            {
                Jwt = _tokenService.GenerateJwt(request.UniqueUserId, request.UniqueCompanyId, companyRole.Value)
            };
        }

        private async Task CreateCompanySignInHistoryAsync(Guid uniqueUserId, Guid uniqueCompanyId)
        {
            await _mediator.Send(new CreateCompanySignInHistoryHandlerRequest
            {
                UniqueUserId = uniqueUserId,
                UniqueCompanyId = uniqueCompanyId
            });
        }
    }
}