using DomainWiki.Common.Requests;
using DomainWiki.Common.Requests.Domain;
using DomainWiki.Core.Requests;
using DomainWiki.Core.Requests.Domain;
using System;

namespace DomainWiki.Core.Maps
{
    public static class RequestMaps
    {
        public static UserLoginRequestInternal ToInternal(this UserLoginRequest request)
                => new UserLoginRequestInternal
                {
                    UserName = request.UserName,
                    Password = request.Password
                };

        public static UserRegisterRequestInternal ToInternal(this UserRegisterRequest request)
            => new UserRegisterRequestInternal
            {
                UserName = request.UserName,
                Password = request.Password
            };

        public static UserDetailsRequestInternal ToUserDetailsInternal(string username)
            => new UserDetailsRequestInternal
            {
                Username = username
            };

        public static DomainCreateRequestInternal ToInternal(this DomainCreateRequest request, Guid creatorUniqueId)
            => new DomainCreateRequestInternal
            {
                Name = request.Name,
                CreatorUniqueId = creatorUniqueId
            };
    }
}