using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Core.Contexts;
using Wiki.Core.Handler_Requests.Company;
using Wiki.Core.HandlerRequests.Company;

namespace Wiki.Core.Handlers.Company
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyHandlerRequest>
    {
        private readonly DataContext _dataContext;
        private readonly IMediator _mediator;

        public CreateCompanyHandler(DataContext dataContext, IMediator mediator)
        {
            _dataContext = dataContext;
            _mediator = mediator;
        }

        async Task<Unit> IRequestHandler<CreateCompanyHandlerRequest, Unit>.Handle(CreateCompanyHandlerRequest request, CancellationToken cancellationToken)
        {
            var userId = await _dataContext.User
                  .Where(u => u.UniqueId == request.CreatorUniqueId)
                  .Select(u => u.Id)
                  .FirstAsync(cancellationToken: cancellationToken);

            var company = new Models.Company
            {
                UniqueId = Guid.NewGuid(),
                CreatedOn = DateTimeOffset.UtcNow,
                Name = request.Name,
                CreatedById = userId
            };

            await _dataContext.Company.AddAsync(company, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);
            await CreateCompanyUserCon(userId, company.Id);

            return Unit.Value;
        }

        private async Task CreateCompanyUserCon(int creatorId, int companyId)
        {
            var editorRole = await _dataContext.CompanyRole
                .Where(cr => cr.Role == Common.Enums.CompanyRole.Editor)
                .Select(cr => cr.Id)
                .FirstAsync();

            await _mediator.Send(new CreateCompanyUserConHandlerRequest
            {
                UserId = creatorId,
                CompanyId = companyId,
                CompanyRoleId = editorRole
            });
        }
    }
}