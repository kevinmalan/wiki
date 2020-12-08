using DomainWiki.Core.Contexts;
using DomainWiki.Core.Requests.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DomainWiki.Core.Services.Handlers.Domain
{
    public class DomainCreateHandler : IRequestHandler<DomainCreateRequestInternal>
    {
        private readonly DataContext _dataContext;

        public DomainCreateHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        async Task<Unit> IRequestHandler<DomainCreateRequestInternal, Unit>.Handle(DomainCreateRequestInternal request, CancellationToken cancellationToken)
        {
            var userId = await _dataContext.User
                  .Where(u => u.UniqueId == request.CreatorUniqueId)
                  .Select(u => u.Id)
                  .FirstAsync(cancellationToken: cancellationToken);

            await _dataContext.Domain.AddAsync(new Models.Domain
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