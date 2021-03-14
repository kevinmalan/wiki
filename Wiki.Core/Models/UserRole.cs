using Wiki.Common.Enums;
using System;
using System.Collections.Generic;

namespace Wiki.Core.Models
{
    public class UserRole
    {
        public UserRole()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public UserRoleName Name { get; set; }
    }
}