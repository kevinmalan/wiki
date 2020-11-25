using DomainWiki.Common.Enums;
using DomainWiki.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DomainWiki.Core.Contexts
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
                .HasConversion(
                    r => r.ToString(),
                    r => (Role)Enum.Parse(typeof(Role), r));
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