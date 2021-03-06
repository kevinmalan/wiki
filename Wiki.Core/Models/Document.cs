using System;

namespace Wiki.Core.Models
{
    public class Document
    {
        public Document()
        {
            UniqueId = Guid.NewGuid();
        }

        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Uri MediaUri { get; set; }
        public int ProjectId { get; set; }
        public int CreatedById { get; set; }

        public User CreatedBy { get; set; }
        public Project Project { get; set; }
    }
}