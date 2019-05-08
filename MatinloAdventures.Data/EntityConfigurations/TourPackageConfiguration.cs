using System.ComponentModel.DataAnnotations.Schema;
using MatinloAdventures.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatinloAdventures.Data.EntityConfigurations
{
    class TourPackageConfiguration : IEntityTypeConfiguration<TourPackage>
    {
        public void Configure(EntityTypeBuilder<TourPackage> entity)
        {
            entity.ToTable("TourPackages");

            entity.HasKey(x => new {x.Id, x.Destination, x.Name});

        }
    }
}
