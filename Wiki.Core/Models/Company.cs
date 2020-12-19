using System;
using System.Collections.Generic;

namespace Wiki.Core.Models
{
    public class Company
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}