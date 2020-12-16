using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Core.Contexts;
using Wiki.Core.Handler_Requests.Project;
using Wiki.Core.Services.Contracts;

namespace Wiki.Core.Handlers.Project
{
    public class CreatePeojectHandler : IRequestHandler<CreateProjectHandlerRequest>
    {
        private readonly DataContext _dataContext;
        private readonly IQueryService _queryService;

        public CreatePeojectHandler(
            DataContext dataContext,
            IQueryService queryService
            )
        {
            _dataContext = dataContext;
            _queryService = queryService;
        }

        public async Task<Unit> Handle(CreateProjectHandlerRequest request, CancellationToken cancellationToken)
        {
            var userId = await _queryService.GetUserIdAsync(request.CreatorUniqueId, cancellationToken);
            var companyId = await _queryService.GetCompanyIdAsync(request.CompanyUniqeId, cancellationToken);

            await _dataContext.AddAsync(
               new Models.Project
               {
                   UniqueId = Guid.NewGuid(),
                   CreatedOn = DateTimeOffset.UtcNow,
                   CreatedById = userId,
                   Name = request.Name,
                   CompanyId = companyId
               });

            await _dataContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}