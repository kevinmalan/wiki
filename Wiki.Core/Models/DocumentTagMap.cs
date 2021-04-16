using System;

namespace Wiki.Core.Models
{
    public class DocumentTagMap
    {
        public DocumentTagMap()
        {
            UniqueId = Guid.NewGuid();
        }

        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public int UniqueDocumentId { get; set; }
        public int UniqueTagId { get; set; }

        public Document Document { get; set; }
        public Tag Tag { get; set; }
    }
}