using MediatR;
using System;

namespace Wiki.Core.Handler_Requests.Document
{
    public class CreateDocumentHandlerRequest : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid UniqueUserId { get; set; }
        public Guid UniqueProjectId { get; set; }
    }
}