using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Common.Enums;
using Wiki.Common.Exceptions;
using Wiki.Common.Responses.Project;
using Wiki.Core.Contexts;
using Wiki.Core.Handler_Requests.Project;
using Wiki.Core.Services.Contracts;

namespace Wiki.Core.Handlers.Project
{
    public class CreatePeojectHandler : IRequestHandler<CreateProjectHandlerRequest, CreateProjectResponse>
    {
        private readonly DataContext _dataContext;
        private readonly IMediator _mediator;
        private readonly IQueryService _queryService;

        public CreatePeojectHandler(
            DataContext dataContext,
            IMediator mediator,
            IQueryService queryService
            )
        {
            _dataContext = dataContext;
            _mediator = mediator;
            _queryService = queryService;
        }

        public async Task<CreateProjectResponse> Handle(CreateProjectHandlerRequest request, CancellationToken cancellationToken)
        {
            var userId = await _queryService.GetUserIdAsync(request.UniqueUserId);
            var companyId = await _queryService.GetCompanyIdAsync(request.UniqueCompanyId);

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new BadRequestException("No project name specified in request.");
            }

            if (request.UniqueUserId == Guid.Empty)
            {
                throw new BadRequestException("No userId specified in request.");
            }

            if (request.UniqueCompanyId == Guid.Empty)
            {
                throw new BadRequestException("No CompanyId specified in request.");
            }

            var project = new Models.Project
            {
                CreatedOn = DateTimeOffset.UtcNow,
                CreatedById = userId,
                Name = request.Name,
                CompanyId = companyId
            };

            await _dataContext.Project.AddAsync(project, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);
            await CreateUserProjectScopeMapAsync(userId, project.Id);

            return new CreateProjectResponse
            {
                UniqueId = project.UniqueId
            };
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