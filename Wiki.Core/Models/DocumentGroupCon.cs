using System;

namespace Wiki.Core.Models
{
    public class DocumentGroupCon
    {
        public int Id { get; set; }
        public Guid DocumentId { get; set; }
        public Document Document { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
    }
}