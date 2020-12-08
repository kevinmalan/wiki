using DomainWiki.Common.Responses;
using MediatR;

namespace DomainWiki.Common.Requests
{
    public class UserLoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}