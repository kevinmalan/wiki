using System;

namespace Wiki.Core.Models
{
    public class ProjectScopePrivilege
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public ProjectScope ProjectScope { get; set; }
        public int ProjectScopeId { get; set; }
        public Privilege Privilege { get; set; }
        public int PrivilegeId { get; set; }
    }
}