using System;

namespace Wiki.Core.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string Name { get; set; }
    }
}