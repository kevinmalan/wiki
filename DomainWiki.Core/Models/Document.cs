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
        public Folder Folder { get; set; }
        public Guid? FolderId { get; set; }
        public Wiki Wiki { get; set; }
        public Guid? WikiId { get; set; }
    }
}