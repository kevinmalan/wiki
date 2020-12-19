using Wiki.Common.Enums;
using System;

namespace Wiki.Common.Responses
{
    public class UserCreatedResponse
    {
        public string UserName { get; set; }
        public Guid UniqueId { get; set; }
    }
}