namespace DomainWiki.Common
{
    public static class Constants
    {
        public static class Claims
        {
            public static string UniqueId => "UniqueId";
            public static string UserName => "UserName";
            public static string Role => "Role";
        }

        public static class Jwt
        {
            public static string Issuer => "jwt:issuer";
            public static string Audiance => "jwt:audiance";
            public static string ExpiresMinutes => "jwt:expiresMinutes";
            public static string SecretKey => "jwt:secretKey";
        }
    }
}