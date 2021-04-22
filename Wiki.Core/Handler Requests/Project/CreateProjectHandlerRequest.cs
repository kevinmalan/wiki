using MediatR;
using System;
using Wiki.Common.Responses.Project;

namespace Wiki.Core.Handler_Requests.Project
{
    public class CreateProjectHandlerRequest : IRequest<CreateProjectResponse>
    {
        public string Name { get; set; }
        public Guid UniqueCompanyId { get; set; }
        public Guid UniqueUserId { get; set; }
    }
}