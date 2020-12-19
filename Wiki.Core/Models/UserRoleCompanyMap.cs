namespace Wiki.Core.Models
{
    public class UserRoleCompanyMap
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public int UserRoleId { get; set; }

        public Company Company { get; set; }
        public User User { get; set; }
        public UserRole UserRole { get; set; }
    }
}