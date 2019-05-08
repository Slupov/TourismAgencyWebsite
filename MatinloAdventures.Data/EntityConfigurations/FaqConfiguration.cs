using MatinloAdventures.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatinloAdventures.Data.EntityConfigurations
{
    public class FaqConfiguration : IEntityTypeConfiguration<Faq>
    {
        public void Configure(EntityTypeBuilder<Faq> entity)
        {
            entity.ToTable("Faqs");
        }
    }
}
