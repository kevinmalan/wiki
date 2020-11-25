using DomainWiki.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DomainWiki.Core.Contexts
{
    public class DomainWikiDbContext : DbContext
    {
        public DomainWikiDbContext(DbContextOptions<DomainWikiDbContext> options) : base(options)
        {
        }

        public DbSet<Domain> Domain { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Wiki> Wiki { get; set; }
        public DbSet<Folder> Folder { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<DocumentTagConnection> DocumentTagConnection { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
    }
}