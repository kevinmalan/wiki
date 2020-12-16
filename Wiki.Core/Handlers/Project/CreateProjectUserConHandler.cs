using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Core.Contexts;
using Wiki.Core.Handler_Requests.Project;
using Wiki.Core.Models;

namespace Wiki.Core.Handlers.Project
{
    public class CreateProjectUserConHandler : IRequestHandler<CreateProjectUserConHandlerRequest>
    {
        private readonly DataContext _dataContext;

        public CreateProjectUserConHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Unit> Handle(CreateProjectUserConHandlerRequest request, CancellationToken cancellationToken)
        {
            await _dataContext.ProjectUserCon.AddAsync(new ProjectUserCon
            {
                UserId = request.UserId,
                ProjectId = request.ProjectId,
                ProjectScopeId = request.ProjectScopeId
            }, cancellationToken);

            await _dataContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}