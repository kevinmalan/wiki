using DomainWiki.Common.Responses;
using MediatR;

namespace DomainWiki.Core.Requests
{
    public class UserRegisterRequestInternal : IRequest<LoginResponse>
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}