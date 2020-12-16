using System;

namespace Wiki.Core.Models
{
    public class Privilege
    {
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public Common.Enums.Action Action { get; set; }
    }
}