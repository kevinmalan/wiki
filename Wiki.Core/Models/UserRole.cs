using Wiki.Common.Enums;
using System;
using System.Collections.Generic;

namespace Wiki.Core.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public Role Role { get; set; }
    }
}