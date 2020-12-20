using Wiki.Common.Enums;
using Wiki.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Wiki.Core.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                  .Entity<UserRole>()
                  .Property(u => u.Name)
                  .HasConversion(new EnumToStringConverter<UserRoleName>());

            modelBuilder
                .Entity<ProjectScope>()
                .Property(p => p.Name)
                .HasConversion(new EnumToStringConverter<ProjectScopeName>());
        }

        public DbSet<Company> Company { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<DocumentTagMap> DocumentTagCon { get; set; }
        public DbSet<ProjectScope> ProjectScope { get; set; }
        public DbSet<UserRoleCompanyMap> UserRoleCompanyMap { get; set; }
        public DbSet<UserProjectScopeMap> UserProjectScopeMap { get; set; }
        public DbSet<CompanySignInHistory> CompanySignInHistory { get; set; }
    }
}