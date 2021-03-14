using Wiki.Common.Enums;
using System;

namespace Wiki.Common.Responses
{
    public class UserResponse
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
    }
}