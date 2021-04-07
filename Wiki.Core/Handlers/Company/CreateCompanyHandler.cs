using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Common.Enums;
using Wiki.Common.Exceptions;
using Wiki.Common.Responses;
using Wiki.Core.Contexts;
using Wiki.Core.Handler_Requests.Company;
using Wiki.Core.HandlerRequests.Company;
using Wiki.Core.Services.Contracts;

namespace Wiki.Core.Handlers.Company
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyHandlerRequest, SignInResponse>
    {
        private readonly DataContext _dataContext;
        private readonly IMediator _mediator;
        private readonly ITokenService _tokenService;

        public CreateCompanyHandler(
            DataContext dataContext,
            IMediator mediator,
            ITokenService tokenService)
        {
            _dataContext = dataContext;
            _mediator = mediator;
            _tokenService = tokenService;
        }

        public async Task<SignInResponse> Handle(CreateCompanyHandlerRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new BadRequestException("No name has been specified for the company.");
            }

            var companyId = await CreateCompanyAsync(request.Name, request.UserId, cancellationToken);
            await CreateUserRoleCompanyMapAsync(request.UserId, companyId);
            await CreateCompanySignInHistoryAsync(request.UserId, companyId);

            return new SignInResponse
            {
                Jwt = _tokenService.GenerateJwt(request.UserId, companyId, UserRoleName.Admin)
            };
        }

        private async Task<Guid> CreateCompanyAsync(string name, Guid userId, CancellationToken cancellationToken)
        {
            var company = new Models.Company
            {
                CreatedOn = DateTimeOffset.UtcNow,
                Name = name,
                CreatedById = userId
            };

            await _dataContext.Company.AddAsync(company, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return company.Id;
        }

        private async Task CreateUserRoleCompanyMapAsync(Guid userId, Guid companyId)
        {
            await _mediator.Send(new CreateUserRoleCompanyMapHandlerRequest
            {
                UserId = userId,
                CompanyId = companyId,
                UserRoleName = UserRoleName.Admin
            });
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