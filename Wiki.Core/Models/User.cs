using System;

namespace Wiki.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }
    }
}