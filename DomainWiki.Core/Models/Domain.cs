using System;
using System.Collections.Generic;

namespace DomainWiki.Core.Models
{
    public class Domain
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}