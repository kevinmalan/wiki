using System;

namespace Wiki.Core.Models
{
    public class ProjectScope
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public Common.Enums.ProjectScope Scope { get; set; }
    }
}