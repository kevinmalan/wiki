using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Wiki.Common.Responses.Document;
using Wiki.Core.Contexts;
using Wiki.Core.Handler_Requests.Document;
using Wiki.Core.Services.Contracts;

namespace Wiki.Core.Handlers.Document
{
    public class CreateDocumentHandler : IRequestHandler<CreateDocumentHandlerRequest, DocumentCreatedResponse>
    {
        private readonly IQueryService _queryService;
        private readonly DataContext _dataContext;

        public CreateDocumentHandler(
           IQueryService queryService,
           DataContext dataContext
          )
        {
            _queryService = queryService;
            _dataContext = dataContext;
        }

        public async Task<DocumentCreatedResponse> Handle(CreateDocumentHandlerRequest request, CancellationToken cancellationToken)
        {
            var userId = await _queryService.GetUserIdAsync(request.UniqueUserId);
            var projectId = await _queryService.GetProjectIdAsync(request.UniqueProjectId);

            var doc = new Models.Document
            {
                CreatedOn = DateTimeOffset.UtcNow,
                Title = request.Title,
                Name = request.Name,
                Content = request.Content,
                CreatedById = userId,
                ProjectId = projectId
            };

            await _dataContext.Document.AddAsync(doc, cancellationToken);

            await _dataContext.SaveChangesAsync(cancellationToken);

            return new DocumentCreatedResponse
            {
                UniqueId = doc.UniqueId
            };
        }
    }
}