using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT_Community.Server.Core.Entities;
using IT_Community.Server.Core.Configurations;
using IT_Community.Server.Core.Entities.Vacancies;

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
            builder.Entity<Post>().Navigation(e => e.Tags).AutoInclude();
            builder.Entity<Post>().Navigation(e => e.Comments).AutoInclude();
            builder.Entity<Post>().Navigation(e => e.User).AutoInclude();
            builder.Entity<Post>().Navigation(e => e.Likes).AutoInclude();
            builder.Entity<Post>().Navigation(e => e.Bookmarks).AutoInclude();
            builder.Entity<Post>().Navigation(e => e.Forum).AutoInclude();
            builder.Entity<Comment>().Navigation(e => e.User).AutoInclude();

            new PostEntityTypeConfiguration().Configure(builder.Entity<Post>());

            new VacancyEntityTypeConfiguration().Configure(builder.Entity<Vacancy>());


            builder.Seed();
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Answer> Answers { get; set; }

    }
}
