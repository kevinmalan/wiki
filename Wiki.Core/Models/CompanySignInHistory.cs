using System;

namespace Wiki.Core.Models
{
    public class CompanySignInHistory
    {
        public int Id { get; set; }
        public Guid UniqueUserId { get; set; }
        public Guid UniqueCompanyId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}