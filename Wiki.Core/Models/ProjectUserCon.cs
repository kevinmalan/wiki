using System;

namespace Wiki.Core.Models
{
    public class ProjectUserCon
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
        public ProjectScope ProjectScope { get; set; }
        public int ProjectScopeId { get; set; }
    }
}