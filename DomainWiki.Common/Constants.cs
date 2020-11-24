namespace DomainWiki.Common
{
    public static class Constants
    {
        public static class Claims
        {
            public static string UniqueId => "uniqueId";
            public static string UserName => "userName";
            public static string Role => "role";
        }

        public static class Jwt
        {
            public static string Issuer => "jwt:issuer";
            public static string Audiance => "jwt:audiance";
            public static string ExpiresMinutes => "jwt:expiresMinutes";
            public static string SecretKey => "jwt:secretKey";
        }

        public class Db
        {
            public static string DomainWikiDbo => "Db:DomainWikiDbo";
        }
    }
}