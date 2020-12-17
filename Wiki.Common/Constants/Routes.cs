namespace Wiki.Common
{
    public static class Routes
    {
        public static class Auth
        {
            public const string Register = "api/auth/register";
            public const string Login = "api/auth/login";
        }

        public static class Health
        {
            public const string Get = "api/health";
        }

        public static class User
        {
            public const string ByUsername = "api/user/{username}/detail";
        }

        public static class Company
        {
            public const string Create = "api/company/create";
        }

        public static class Project
        {
            public const string Create = "api/company/{companyUniqueId}/project/create";
        }

        public static class Document
        {
            public const string Create = "api/project/{projectUniqueId}/document/create";
        }
    }
}