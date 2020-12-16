using System;

namespace Wiki.Core.Models
{
    public class CompanyRolePrivilege
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public CompanyRole CompanyRole { get; set; }
        public int CompanyRoleId { get; set; }
        public Privilege Privilege { get; set; }
        public int PrivilegeId { get; set; }
    }
}