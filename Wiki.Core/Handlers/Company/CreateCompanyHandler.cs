using Wiki.Core.Contexts;
using Wiki.Core.HandlerRequests.Company;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Wiki.Core.Handlers.Company
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyHandlerRequest>
    {
        private readonly DataContext _dataContext;

        public CreateCompanyHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        async Task<Unit> IRequestHandler<CreateCompanyHandlerRequest, Unit>.Handle(CreateCompanyHandlerRequest request, CancellationToken cancellationToken)
        {
            var userId = await _dataContext.User
                  .Where(u => u.UniqueId == request.CreatorUniqueId)
                  .Select(u => u.Id)
                  .FirstAsync(cancellationToken: cancellationToken);

            await _dataContext.Company.AddAsync(new Models.Company
            {
                UniqueId = Guid.NewGuid(),
                CreatedOn = DateTimeOffset.UtcNow,
                Name = request.Name,
                CreatedById = userId
            }, cancellationToken);

            await _dataContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}