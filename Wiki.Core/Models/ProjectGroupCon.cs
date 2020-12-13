using System;

namespace Wiki.Core.Models
{
    public class ProjectGroupCon
    {
        public int Id { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
    }
}