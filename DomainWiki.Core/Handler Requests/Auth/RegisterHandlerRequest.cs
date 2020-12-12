using DomainWiki.Common.Responses;
using MediatR;

namespace DomainWiki.Core.HandlerRequests.Auth
{
    public class RegisterHandlerRequest : IRequest<SignInResponse>
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}