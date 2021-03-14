using System;

namespace Wiki.Core.Models
{
    public class UserRoleCompanyMap
    {
        public UserRoleCompanyMap()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid UserId { get; set; }
        public Guid UserRoleId { get; set; }

        public Company Company { get; set; }
        public User User { get; set; }
        public UserRole UserRole { get; set; }
    }
}