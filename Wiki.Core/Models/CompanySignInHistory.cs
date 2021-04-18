using System;

namespace Wiki.Core.Models
{
    public class CompanySignInHistory
    {
        public CompanySignInHistory()
        {
            UniqueId = Guid.NewGuid();
        }

        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

        public User User { get; set; }
        public Company Company { get; set; }
    }
}