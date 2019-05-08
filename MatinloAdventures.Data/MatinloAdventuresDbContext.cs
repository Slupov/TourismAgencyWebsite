using MatinloAdventures.Data.EntityConfigurations;
using MatinloAdventures.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MatinloAdventures.Data
{
    public class MatinloAdventuresDbContext : IdentityDbContext<ApplicationUser>
    {
        public MatinloAdventuresDbContext(DbContextOptions<MatinloAdventuresDbContext> options)
            : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }

        public DbSet<TourPackage> TourPackages { get; set; }
        public DbSet<TourPackageComment> TourPackageComments { get; set; }

        public DbSet<Faq> Faqs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new BlogPostConfiguration());
            builder.ApplyConfiguration(new BlogCommentConfiguration());

            builder.ApplyConfiguration(new FaqConfiguration());

            builder.ApplyConfiguration(new TourPackageConfiguration());
            builder.ApplyConfiguration(new TourPackageCommentConfiguration());
        }
    }
}
