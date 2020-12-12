using Wiki.Common.Enums;
using System;

namespace Wiki.Common.Responses
{
    public class UserResponse
    {
        public Guid UniqueId { get; set; }
        public string UserName { get; set; }
        public Role Role { get; set; }
    }
}