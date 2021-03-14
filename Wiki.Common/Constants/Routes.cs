namespace Wiki.Common
{
    public static class Routes
    {
        public static class Auth
        {
            public const string Register = "api/auth/register";
            public const string SignIn = "api/auth/signin";
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
            public const string SignIn = "api/company/{companyId}/signin";
        }

        public static class Project
        {
            public const string Create = "api/company/{companyId}/project/create";
        }

        public static class Document
        {
            public const string Create = "api/project/{projectId}/document/create";
        }
    }
}