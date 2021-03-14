using System;
using System.Collections.Generic;

namespace Wiki.Core.Models
{
    public class Project
    {
        public Project()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public User CreatedBy { get; set; }
        public Guid CreatedById { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}