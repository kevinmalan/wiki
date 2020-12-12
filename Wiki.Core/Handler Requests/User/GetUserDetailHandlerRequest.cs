using Wiki.Common.Responses;
using MediatR;

namespace Wiki.Core.Requests
{
    public class GetUserDetailHandlerRequest : IRequest<UserResponse>
    {
        public string Username { get; set; }
    }
}