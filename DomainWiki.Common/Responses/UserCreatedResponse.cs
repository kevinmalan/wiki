using System;

namespace DomainWiki.Common.Responses
{
    public class UserCreatedResponse
    {
        public string UserName { get; set; }
        public string Role { get; set; }
        public Guid UniqueId { get; set; }
    }
}