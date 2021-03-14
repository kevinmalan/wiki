using System;

namespace Wiki.Core.Models
{
    public class CompanySignInHistory
    {
        public CompanySignInHistory()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}