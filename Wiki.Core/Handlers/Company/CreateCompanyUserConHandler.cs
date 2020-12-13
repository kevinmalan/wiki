using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Core.Contexts;
using Wiki.Core.Handler_Requests.Company;
using Wiki.Core.Models;

namespace Wiki.Core.Handlers.Company
{
    public class CreateCompanyUserConHandler : IRequestHandler<CreateCompanyUserConHandlerRequest>
    {
        private readonly DataContext _dataContext;

        public CreateCompanyUserConHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Unit> Handle(CreateCompanyUserConHandlerRequest request, CancellationToken cancellationToken)
        {
            await _dataContext.CompanyUserCon.AddAsync(new CompanyUserCon
            {
                UserId = request.UserId,
                CompanyId = request.CompanyId,
                CompanyRoleId = request.CompanyRoleId
            }, cancellationToken);

            await _dataContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}