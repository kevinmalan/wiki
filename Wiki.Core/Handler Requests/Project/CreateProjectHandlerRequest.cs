using MediatR;
using System;

namespace Wiki.Core.Handler_Requests.Project
{
    public class CreateProjectHandlerRequest : IRequest
    {
        public string Name { get; set; }
        public Guid CompanyId { get; set; }
        public Guid UserId { get; set; }
    }
}