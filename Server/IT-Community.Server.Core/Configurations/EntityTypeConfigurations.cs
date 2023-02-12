﻿using IT_Community.Server.Core.Entities;
using IT_Community.Server.Core.Entities.Vacancies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Core.Configurations
{
    public class PostEntityTypeConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasMany(x => x.Tags).WithMany(x => x.Posts);
            builder.HasMany(x => x.Comments).WithOne(x => x.Post).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Likes).WithOne(x => x.Post).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Restrict);
        }
    }
    public class VacancyEntityTypeConfiguration : IEntityTypeConfiguration<Vacancy>
    {
        public void Configure(EntityTypeBuilder<Vacancy> builder)
        {
            builder.HasMany(x => x.Categories).WithMany(x => x.Vacancies);
            builder.HasMany(x => x.Answers).WithOne(x => x.Vacancy).HasForeignKey(x => x.VacancyId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}