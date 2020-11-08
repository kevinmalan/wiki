using System;
using System.Collections.Generic;

namespace DomainWiki.Core.Models
{
    public class Project
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public Domain Domain { get; set; }
        public Guid DomainId { get; set; }
        public Group Group { get; set; }
        public Guid? GroupId { get; set; }
        public ICollection<Wiki> Wikis { get; set; }
    }
}