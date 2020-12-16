using MediatR;

namespace Wiki.Core.Handler_Requests.Project
{
    public class CreateProjectUserConHandlerRequest : IRequest
    {
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public int ProjectScopeId { get; set; }
    }
}