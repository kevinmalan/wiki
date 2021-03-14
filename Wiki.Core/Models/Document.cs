using System;

namespace Wiki.Core.Models
{
    public class Document
    {
        public Document()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string Title { get; set; }
        public Uri ContentUri { get; set; }
        public Guid ProjectId { get; set; }

        public Project Project { get; set; }
    }
}