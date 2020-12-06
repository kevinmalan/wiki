using DomainWiki.Common.Requests;
using DomainWiki.Core.Requests;

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
    }
}