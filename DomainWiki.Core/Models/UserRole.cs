using DomainWiki.Common.Enums;
using System;
using System.Collections.Generic;

namespace DomainWiki.Core.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string Role { get; set; }
    }
}