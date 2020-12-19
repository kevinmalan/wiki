using System;
using Wiki.Common.Enums;

namespace Wiki.Core.Models
{
    public class ProjectScope
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public ProjectScopeName Name { get; set; }
    }
}