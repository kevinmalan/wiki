using System;
using System.Collections.Generic;

namespace Wiki.Core.Models
{
    public class Project
    {
        public Project()
        {
            UniqueId = Guid.NewGuid();
        }

        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public int CompanyId { get; set; }
        public int CreatedById { get; set; }

        public Company Company { get; set; }
        public User CreatedBy { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}