using MediatR;
using System;

namespace Wiki.Core.Handler_Requests.Project
{
    public class CreateProjectHandlerRequest : IRequest
    {
        public string Name { get; set; }
        public Guid CompanyUniqeId { get; set; }
        public Guid CreatorUniqueId { get; set; }
    }
}