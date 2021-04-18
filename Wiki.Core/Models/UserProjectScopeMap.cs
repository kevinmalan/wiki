using System;

namespace Wiki.Core.Models
{
    public class UserProjectScopeMap
    {
        public UserProjectScopeMap()
        {
            UniqueId = Guid.NewGuid();
        }

        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public int ProjectScopeId { get; set; }

        public User User { get; set; }
        public Project Project { get; set; }
        public ProjectScope ProjectScope { get; set; }
    }
}