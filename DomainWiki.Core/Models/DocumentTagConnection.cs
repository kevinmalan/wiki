using System;
using System.Collections.Generic;
using System.Text;

namespace DomainWiki.Core.Models
{
    public class DocumentTagConnection
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public Tag Tag { get; set; }
        public Guid TagId { get; set; }
        public Document Document { get; set; }
        public Guid DocumentId { get; set; }
    }
}
