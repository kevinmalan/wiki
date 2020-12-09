namespace DomainWiki.Common
{
    public static class Jwt
    {
        public static string Issuer => "jwt:issuer";
        public static string Audiance => "jwt:audiance";
        public static string ExpiresMinutes => "jwt:expiresMinutes";
        public static string SecretKey => "jwt:secretKey";
    }
}