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
        public Guid UniqueUserId { get; set; }
        public Guid UniqueProjectId { get; set; }
        public Guid UniqueProjectScopeId { get; set; }
    }
}