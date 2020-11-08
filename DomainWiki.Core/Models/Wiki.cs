using System;
using System.Collections.Generic;

namespace DomainWiki.Core.Models
{
    public class Wiki
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public Project Project { get; set; }
        public Guid ProjectId { get; set; }
        public ICollection<Folder> Folders { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}