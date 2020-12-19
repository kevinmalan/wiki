using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Common.Enums;
using Wiki.Core.Contexts;
using Wiki.Core.Handler_Requests.Company;
using Wiki.Core.HandlerRequests.Company;
using Wiki.Core.Services.Contracts;

namespace Wiki.Core.Handlers.Company
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyHandlerRequest>
    {
        private readonly DataContext _dataContext;
        private readonly IMediator _mediator;
        private readonly IQueryService _queryService;

        public CreateCompanyHandler(
            DataContext dataContext,
            IMediator mediator,
            IQueryService queryService)
        {
            _dataContext = dataContext;
            _mediator = mediator;
            _queryService = queryService;
        }

        async Task<Unit> IRequestHandler<CreateCompanyHandlerRequest, Unit>.Handle(CreateCompanyHandlerRequest request, CancellationToken cancellationToken)
        {
            var userId = await _queryService.GetUserIdAsync(request.CreatorUniqueId, cancellationToken);

            var company = new Models.Company
            {
                UniqueId = Guid.NewGuid(),
                CreatedOn = DateTimeOffset.UtcNow,
                Name = request.Name,
                CreatedById = userId
            };

            await _dataContext.Company.AddAsync(company, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);
            await CreateUserRoleCompanyMapAsync(userId, company.Id);

            return Unit.Value;
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
    }
}