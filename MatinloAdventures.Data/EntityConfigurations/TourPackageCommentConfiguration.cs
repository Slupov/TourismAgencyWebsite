using System;
using MatinloAdventures.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatinloAdventures.Data.EntityConfigurations
{
    public class TourPackageCommentConfiguration : IEntityTypeConfiguration<TourPackageComment>
    {
        public void Configure(EntityTypeBuilder<TourPackageComment> entity)
        {
            entity.ToTable("TourPackageComments");

            entity
                .Property(x => x.Content)
                .HasDefaultValue("");

            entity
                .Property(x => x.DateCreated)
                .HasDefaultValue(DateTime.Now);
        }
    }
}
