using System;
using System.Collections.Generic;

namespace DomainWiki.Core.Models
{
    public class Folder
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public Wiki Wiki { get; set; }
        public Guid? WikiId { get; set; }
        public Folder FolderParent { get; set; }
        public Guid? FolderParentId { get; set; }
        public ICollection<Folder> Folders { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}