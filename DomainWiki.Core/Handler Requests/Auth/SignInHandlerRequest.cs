using DomainWiki.Common.Responses;
using MediatR;

namespace DomainWiki.Core.HandlerRequests.Auth
{
    public class SignInHandlerRequest : IRequest<SignInResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}