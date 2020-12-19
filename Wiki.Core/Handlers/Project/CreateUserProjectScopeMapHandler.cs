using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Core.Contexts;
using Wiki.Core.Handler_Requests.Project;
using Wiki.Core.Models;
using Wiki.Core.Services.Contracts;

namespace Wiki.Core.Handlers.Project
{
    public class CreateUserProjectScopeMapHandler : IRequestHandler<CreateUserProjectScopeMapHandlerRequest>
    {
        private readonly DataContext _dataContext;
        private readonly IQueryService _queryService;

        public CreateUserProjectScopeMapHandler(
            DataContext dataContext,
            IQueryService queryService)
        {
            _dataContext = dataContext;
            _queryService = queryService;
        }

        public async Task<Unit> Handle(CreateUserProjectScopeMapHandlerRequest request, CancellationToken cancellationToken)
        {
            foreach (var scope in request.ProjectScopeNames)
            {
                var projectScopeId = await _queryService.GetProjectScopeIdAsync(scope, cancellationToken);

                await _dataContext.UserProjectScopeMap.AddAsync(new UserProjectScopeMap
                {
                    UserId = request.UserId,
                    ProjectId = request.ProjectId,
                    ProjectScopeId = projectScopeId
                }, cancellationToken);
            }

            await _dataContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}