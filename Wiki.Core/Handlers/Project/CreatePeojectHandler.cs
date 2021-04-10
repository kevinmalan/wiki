using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Common.Enums;
using Wiki.Common.Exceptions;
using Wiki.Core.Contexts;
using Wiki.Core.Handler_Requests.Project;
using Wiki.Core.Services.Contracts;

namespace Wiki.Core.Handlers.Project
{
    public class CreatePeojectHandler : IRequestHandler<CreateProjectHandlerRequest>
    {
        private readonly DataContext _dataContext;
        private readonly IMediator _mediator;

        public CreatePeojectHandler(
            DataContext dataContext,
            IMediator mediator
            )
        {
            _dataContext = dataContext;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreateProjectHandlerRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new BadRequestException("No project name specified in request.");
            }

            if (request.UserId == Guid.Empty)
            {
                throw new BadRequestException("No userId specified in request.");
            }

            if (request.CompanyId == Guid.Empty)
            {
                throw new BadRequestException("No CompanyId specified in request.");
            }

            var project = new Models.Project
            {
                CreatedOn = DateTimeOffset.UtcNow,
                CreatedById = request.UserId,
                Name = request.Name,
                CompanyId = request.CompanyId
            };

            await _dataContext.AddAsync(project, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);
            await CreateUserProjectScopeMapAsync(request.UserId, project.Id);

            return Unit.Value;
        }

        private async Task CreateUserProjectScopeMapAsync(Guid userId, Guid projectId)
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