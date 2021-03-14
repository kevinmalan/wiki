using System;
using Wiki.Common.Enums;

namespace Wiki.Core.Models
{
    public class ProjectScope
    {
        public ProjectScope()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public ProjectScopeName Name { get; set; }
    }
}