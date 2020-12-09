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

        public static class Db
        {
            public static string DomainWikiDbo => "Db:DomainWikiDbo";
        }

        public static class Routes
        {
            public static class Auth
            {
                public const string Register = "api/auth/register";
                public const string Login = "api/auth/login";
            }

            public static class User
            {
                public const string ByUsername = "api/user/{username}/detail";
            }

            public static class Domain
            {
                public const string Create = "api/domain/create";
            }
        }

        public static class Swagger
        {
            public const string Auth = "Auth";
        }
    }
}