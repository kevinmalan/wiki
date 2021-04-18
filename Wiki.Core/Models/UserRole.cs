using Wiki.Common.Enums;
using System;
using System.Collections.Generic;

namespace Wiki.Core.Models
{
    public class UserRole
    {
        public UserRole()
        {
            UniqueId = Guid.NewGuid();
        }

        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public UserRoleName Name { get; set; }
    }
}