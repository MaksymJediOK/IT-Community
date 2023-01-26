using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT_Community.Server.Core.Entities;

namespace IT_Community.Server.Core
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            new PostEntityTypeConfiguration().Configure(builder.Entity<Post>());
            base.OnModelCreating(builder);
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
    }
}
