using System;

namespace Wiki.Core.Models
{
    public class Group
    {
        public Group()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}