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
                  .Property(u => u.Role)
                  .HasConversion(new EnumToStringConverter<SystemRole>());

            modelBuilder
                .Entity<Models.CompanyRole>()
                .Property(c => c.Role)
                .HasConversion(new EnumToStringConverter<Common.Enums.CompanyRole>());

            modelBuilder
                .Entity<Models.ProjectScope>()
                .Property(p => p.Scope)
                .HasConversion(new EnumToStringConverter<Common.Enums.ProjectScope>());

            modelBuilder
                .Entity<Privilege>()
                .Property(p => p.Action)
                .HasConversion(new EnumToStringConverter<Action>());
        }

        public DbSet<Company> Company { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Models.CompanyRole> CompanyRole { get; set; }
        public DbSet<DocumentTagCon> DocumentTagCon { get; set; }
        public DbSet<DocumentGroupCon> DocumentGroupCon { get; set; }
        public DbSet<ProjectGroupCon> ProjectGroupCon { get; set; }
        public DbSet<CompanyUserCon> CompanyUserCon { get; set; }
        public DbSet<Models.ProjectScope> ProjectScope { get; set; }
        public DbSet<ProjectUserCon> ProjectUserCon { get; set; }
        public DbSet<Privilege> Privilege { get; set; }
        public DbSet<CompanyRolePrivilege> CompanyRolePrivilege { get; set; }
    }
}