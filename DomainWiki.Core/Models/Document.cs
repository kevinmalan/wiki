using System;

namespace DomainWiki.Core.Models
{
    public class Document
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string Title { get; set; }
        public Uri ContentUri { get; set; }
        public Project Project { get; set; }
        public Guid ProjectId { get; set; }
    }
}