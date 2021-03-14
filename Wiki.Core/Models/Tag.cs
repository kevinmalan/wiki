using System;

namespace Wiki.Core.Models
{
    public class Tag
    {
        public Tag()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}