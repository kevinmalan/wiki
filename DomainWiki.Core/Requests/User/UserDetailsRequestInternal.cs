using DomainWiki.Common.Responses;
using MediatR;

namespace DomainWiki.Core.Requests
{
    public class UserDetailsRequestInternal : IRequest<UserResponse>
    {
        public string Username { get; set; }
    }
}