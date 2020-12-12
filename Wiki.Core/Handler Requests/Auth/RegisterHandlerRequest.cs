using Wiki.Common.Responses;
using MediatR;

namespace Wiki.Core.HandlerRequests.Auth
{
    public class RegisterHandlerRequest : IRequest<SignInResponse>
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}