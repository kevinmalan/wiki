using System;

namespace Wiki.Core.Models
{
    public class DocumentGroup
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public Guid DocumentId { get; set; }
        public Document Document { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
    }
}