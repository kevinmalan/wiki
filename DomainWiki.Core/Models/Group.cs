using System;

namespace DomainWiki.Core.Models
{
    public class Group
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}