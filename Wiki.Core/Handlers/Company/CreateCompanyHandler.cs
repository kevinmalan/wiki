using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Common.Enums;
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
        private readonly IQueryService _queryService;
        private readonly ITokenService _tokenService;

        public CreateCompanyHandler(
            DataContext dataContext,
            IMediator mediator,
            IQueryService queryService,
            ITokenService tokenService)
        {
            _dataContext = dataContext;
            _mediator = mediator;
            _queryService = queryService;
            _tokenService = tokenService;
        }

        public async Task<SignInResponse> Handle(CreateCompanyHandlerRequest request, CancellationToken cancellationToken)
        {
            var userId = await _queryService.GetUserIdAsync(request.CreatorUniqueId, cancellationToken);
            var created = await CreateCompanyAsync(request.Name, userId, cancellationToken);
            await CreateUserRoleCompanyMapAsync(userId, created.Item1);
            await CreateCompanySignInHistoryAsync(request.CreatorUniqueId, created.Item2);

            return new SignInResponse
            {
                Jwt = _tokenService.GenerateJwt(request.CreatorUniqueId, created.Item2, UserRoleName.Admin)
            };
        }

        private async Task<(int, Guid)> CreateCompanyAsync(string name, int userId, CancellationToken cancellationToken)
        {
            var company = new Models.Company
            {
                UniqueId = Guid.NewGuid(),
                CreatedOn = DateTimeOffset.UtcNow,
                Name = name,
                CreatedById = userId
            };

            await _dataContext.Company.AddAsync(company, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return (company.Id, company.UniqueId);
        }

        private async Task CreateUserRoleCompanyMapAsync(int creatorId, int companyId)
        {
            await _mediator.Send(new CreateUserRoleCompanyMapHandlerRequest
            {
                UserId = creatorId,
                CompanyId = companyId,
                UserRoleName = UserRoleName.Admin
            });
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