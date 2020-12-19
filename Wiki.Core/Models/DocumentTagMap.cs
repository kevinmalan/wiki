using System;

namespace Wiki.Core.Models
{
    public class DocumentTagMap
    {
        public int Id { get; set; }
        public Guid DocumentId { get; set; }
        public Guid TagId { get; set; }

        public Document Document { get; set; }
        public Tag Tag { get; set; }
    }
}