using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Common.Exceptions;
using Wiki.Core.Contexts;
using Wiki.Core.Handler_Requests.Company;
using Wiki.Core.Models;
using Wiki.Core.Services.Contracts;

namespace Wiki.Core.Handlers.Company
{
    public class CreateUserRoleCompanyMapHandler : IRequestHandler<CreateUserRoleCompanyMapHandlerRequest>
    {
        private readonly DataContext _dataContext;
        private readonly IQueryService _queryService;

        public CreateUserRoleCompanyMapHandler(
            DataContext dataContext,
             IQueryService queryService)
        {
            _dataContext = dataContext;
            _queryService = queryService;
        }

        public async Task<Unit> Handle(CreateUserRoleCompanyMapHandlerRequest request, CancellationToken cancellationToken)
        {
            if (request.UserRoleName == 0)
            {
                throw new BadRequestException("No UserRole specified in request.");
            }

            if (request.CompanyId == Guid.Empty)
            {
                throw new BadRequestException("No CompanyId specified in request.");
            }

            if (request.UserId == Guid.Empty)
            {
                throw new BadRequestException("No UserId specified in request.");
            }

            var roleId = await _queryService.GetUserRoleIdAsync(request.UserRoleName, cancellationToken);

            await _dataContext.UserRoleCompanyMap.AddAsync(
                new UserRoleCompanyMap
                {
                    CompanyId = request.CompanyId,
                    UserId = request.UserId,
                    UserRoleId = roleId
                },
                cancellationToken
            );

            await _dataContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}