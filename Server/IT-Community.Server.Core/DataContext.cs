using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT_Community.Server.Core.Entities;
using IT_Community.Server.Core.Configurations;

namespace IT_Community.Server.Core
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Post>().HasMany(x => x.Tags).WithMany(x => x.Posts);
            builder.Entity<Post>().HasMany(x => x.Comments).WithOne(x => x.Post).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Post>().HasMany(x => x.Likes).WithOne(x => x.Post).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Post>().Navigation(e => e.Tags).AutoInclude();
            builder.Entity<Post>().Navigation(e => e.Comments).AutoInclude();
            builder.Entity<Post>().Navigation(e => e.User).AutoInclude();
            builder.Entity<Post>().Navigation(e => e.Likes).AutoInclude();
            builder.Entity<Post>().Navigation(e => e.Forum).AutoInclude();
            builder.Entity<Comment>().Navigation(e => e.User).AutoInclude();
            new PostEntityTypeConfiguration().Configure(builder.Entity<Post>());
            builder.Seed();
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
    }
}
