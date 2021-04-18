using MediatR;
using System;
using Wiki.Common.Enums;

namespace Wiki.Core.Handler_Requests.Project
{
    public class CreateUserProjectScopeMapHandlerRequest : IRequest
    {
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public ProjectScopeName[] ProjectScopeNames { get; set; }
    }
}