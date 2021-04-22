using System;

namespace Wiki.Common.Responses
{
    public class CompanySignInResponse
    {
        public Guid? UniqueId { get; set; }
        public string Jwt { get; set; }
    }
}