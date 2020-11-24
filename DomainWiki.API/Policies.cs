using Microsoft.AspNetCore.Authorization;

namespace DomainWiki.API
{
    public class Policies
    {
        public const string Admin = "Admin";
        public const string Member = "Member";

        public static AuthorizationPolicy AdminPolicy()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireRole(Admin).Build();
        }

        public static AuthorizationPolicy MemberPolicy()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireRole(Member).Build();
        }
    }
}