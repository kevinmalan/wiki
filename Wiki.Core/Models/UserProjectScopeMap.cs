using System;

namespace Wiki.Core.Models
{
    public class UserProjectScopeMap
    {
        public UserProjectScopeMap()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid ProjectScopeId { get; set; }

        public User User { get; set; }
        public Project Project { get; set; }
        public ProjectScope ProjectScope { get; set; }
    }
}