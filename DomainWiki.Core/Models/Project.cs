using System;
using System.Collections.Generic;

namespace DomainWiki.Core.Models
{
    public class Project
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}