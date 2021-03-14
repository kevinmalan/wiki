using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Core.Contexts;
using Wiki.Core.Handler_Requests.Company;
using Wiki.Core.Models;

namespace Wiki.Core.Handlers.Company
{
    public class CreateCompanySignInHistoryHandler : IRequestHandler<CreateCompanySignInHistoryHandlerRequest>
    {
        private readonly DataContext _dataContext;

        public CreateCompanySignInHistoryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Unit> Handle(CreateCompanySignInHistoryHandlerRequest request, CancellationToken cancellationToken)
        {
            await _dataContext.CompanySignInHistory.AddAsync(
                 new CompanySignInHistory
                 {
                     UserId = request.UserId,
                     CompanyId = request.CompanyId,
                     CreatedOn = DateTimeOffset.UtcNow
                 }, cancellationToken
              );

            await _dataContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}