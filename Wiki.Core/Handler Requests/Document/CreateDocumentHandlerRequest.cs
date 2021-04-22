using MediatR;
using System;
using Wiki.Common.Responses.Document;

namespace Wiki.Core.Handler_Requests.Document
{
    public class CreateDocumentHandlerRequest : IRequest<DocumentCreatedResponse>
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid UniqueUserId { get; set; }
        public Guid UniqueProjectId { get; set; }
    }
}