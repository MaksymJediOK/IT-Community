using IT_Community.Server.Core.Configurations;
using IT_Community.Server.Core.Entities;
using IT_Community.Server.Core.Entities.Vacancies;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
