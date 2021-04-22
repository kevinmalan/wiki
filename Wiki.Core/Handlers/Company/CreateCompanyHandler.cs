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
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyHandlerRequest, CompanySignInResponse>
    {
        private readonly DataContext _dataContext;
        private readonly IMediator _mediator;
        private readonly ITokenService _tokenService;
        private readonly IQueryService _queryService;

        public CreateCompanyHandler(
            DataContext dataContext,
            IMediator mediator,
            ITokenService tokenService,
            IQueryService queryService)
        {
            _dataContext = dataContext;
            _mediator = mediator;
            _tokenService = tokenService;
            _queryService = queryService;
        }

        public async Task<CompanySignInResponse> Handle(CreateCompanyHandlerRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new BadRequestException("No company name specified in request.");
            }

            if (request.UniqueUserId == Guid.Empty)
            {
                throw new BadRequestException("No UniqueUserId specified in request.");
            }

            var userId = await _queryService.GetUserIdAsync(request.UniqueUserId);
            var company = await CreateCompanyAsync(request.Name, userId, cancellationToken);

            await CreateUserRoleCompanyMapAsync(userId, company.Id);
            await CreateCompanySignInHistoryAsync(userId, company.Id);

            return new CompanySignInResponse
            {
                UniqueId = company.UniqueId,
                Jwt = _tokenService.GenerateJwt(request.UniqueUserId, company.UniqueId, UserRoleName.Admin)
            };
        }

        private async Task<Models.Company> CreateCompanyAsync(string name, int userId, CancellationToken cancellationToken)
        {
            var company = new Models.Company
            {
                CreatedOn = DateTimeOffset.UtcNow,
                Name = name,
                CreatedById = userId
            };

            await _dataContext.Company.AddAsync(company, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return company;
        }

        private async Task CreateUserRoleCompanyMapAsync(int userId, int companyId)
        {
            await _mediator.Send(new CreateUserRoleCompanyMapHandlerRequest
            {
                UserId = userId,
                CompanyId = companyId,
                UserRoleName = UserRoleName.Admin
            });
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