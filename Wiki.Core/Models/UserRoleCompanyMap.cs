using System;

namespace Wiki.Core.Models
{
    public class UserRoleCompanyMap
    {
        public UserRoleCompanyMap()
        {
            UniqueId = Guid.NewGuid();
        }

        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public int UserRoleId { get; set; }

        public Company Company { get; set; }
        public User User { get; set; }
        public UserRole UserRole { get; set; }
    }
}