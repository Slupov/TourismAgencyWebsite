using System;
using MatinloAdventures.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatinloAdventures.Data.EntityConfigurations
{
    public class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> entity)
        {
            entity.ToTable("BlogPosts");

            entity
                .Property(x => x.DateCreated)
                .HasDefaultValue(DateTime.Now);

            entity
                .HasMany(c => c.Comments)
                .WithOne(c => c.BlogPost);
        }
    }
}
