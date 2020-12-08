using System;

namespace DomainWiki.Core.Models
{
    public class ProjectGroup
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
    }
}