using System;

namespace Wiki.Core.Models
{
    public class CompanySignInHistory
    {
        public int Id { get; set; }
        public Guid UserUniqueId { get; set; }
        public Guid CompanyUniqueId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}