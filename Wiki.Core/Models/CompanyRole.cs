using System;

namespace Wiki.Core.Models
{
    public class CompanyRole
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public Common.Enums.CompanyRole Role { get; set; }
        public bool AllowCreateProject { get; set; }
    }
}