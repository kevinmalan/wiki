using MediatR;
using System;

namespace Wiki.Core.Handler_Requests.Project
{
    public class CreateProjectHandlerRequest : IRequest
    {
        public string Name { get; set; }
        public Guid UniqueCompanyId { get; set; }
        public Guid UniqueUserId { get; set; }
    }
}