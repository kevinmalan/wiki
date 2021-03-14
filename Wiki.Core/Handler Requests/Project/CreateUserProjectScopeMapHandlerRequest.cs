using MediatR;
using System;
using Wiki.Common.Enums;

namespace Wiki.Core.Handler_Requests.Project
{
    public class CreateUserProjectScopeMapHandlerRequest : IRequest
    {
        public Guid UserId { get; set; }
        public Guid ProjectId { get; set; }
        public ProjectScopeName[] ProjectScopeNames { get; set; }
    }
}