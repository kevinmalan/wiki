namespace Wiki.Core.Models
{
    public class CompanyUserCon
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int CompanyRoleId { get; set; }
        public CompanyRole CompanyRole { get; set; }
    }
}