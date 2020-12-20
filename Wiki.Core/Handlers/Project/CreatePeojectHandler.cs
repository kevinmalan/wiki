using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Common.Enums;
using Wiki.Core.Contexts;
using Wiki.Core.Handler_Requests.Project;
using Wiki.Core.Services.Contracts;

namespace Wiki.Core.Handlers.Project
{
    public class CreatePeojectHandler : IRequestHandler<CreateProjectHandlerRequest>
    {
        private readonly DataContext _dataContext;
        private readonly IQueryService _queryService;
        private readonly IMediator _mediator;

        public CreatePeojectHandler(
            DataContext dataContext,
            IQueryService queryService,
            IMediator mediator
            )
        {
            _dataContext = dataContext;
            _queryService = queryService;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreateProjectHandlerRequest request, CancellationToken cancellationToken)
        {
            var userId = await _queryService.GetUserIdAsync(request.UniqueUserId, cancellationToken);
            var companyId = await _queryService.GetCompanyIdAsync(request.UniqueCompanyId, cancellationToken);
            var project = new Models.Project
            {
                UniqueId = Guid.NewGuid(),
                CreatedOn = DateTimeOffset.UtcNow,
                CreatedById = userId,
                Name = request.Name,
                CompanyId = companyId
            };

            await _dataContext.AddAsync(project, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);
            await CreateUserProjectScopeMapAsync(userId, project.Id);

            return Unit.Value;
        }

        private async Task CreateUserProjectScopeMapAsync(int userId, int projectId)
        {
            await _mediator.Send(new CreateUserProjectScopeMapHandlerRequest
            {
                UserId = userId,
                ProjectId = projectId,
                ProjectScopeNames = new ProjectScopeName[]
                {
                    ProjectScopeName.ReadDocument,
                    ProjectScopeName.CreateDocument,
                    ProjectScopeName.EditDocument,
                    ProjectScopeName.DeleteDocument
                }
            });
        }
    }
}