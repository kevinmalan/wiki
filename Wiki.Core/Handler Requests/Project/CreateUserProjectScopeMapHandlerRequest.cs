using MediatR;
using System;
using Wiki.Common.Enums;

namespace Wiki.Core.Handler_Requests.Project
{
    public class CreateUserProjectScopeMapHandlerRequest : IRequest
    {
        public Guid UniqueUserId { get; set; }
        public Guid UniqueProjectId { get; set; }
        public ProjectScopeName[] ProjectScopeNames { get; set; }
    }
}