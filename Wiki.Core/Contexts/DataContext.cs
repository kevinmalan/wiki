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
                  .HasConversion(new EnumToStringConverter<Role>());
        }

        public DbSet<Company> Domain { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<DocumentTagCon> DocumentTag { get; set; }
        public DbSet<DocumentGroupCon> DocumentGroup { get; set; }
        public DbSet<ProjectGroupCon> ProjectGroup { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
    }
}