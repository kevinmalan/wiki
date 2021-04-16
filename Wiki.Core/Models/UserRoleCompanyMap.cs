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
        public Guid UniqueCompanyId { get; set; }
        public Guid UniqueUserId { get; set; }
        public Guid UniqueUserRoleId { get; set; }
    }
}