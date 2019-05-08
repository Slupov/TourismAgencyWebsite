using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(MatinloAdventures.Web.Areas.Identity.IdentityHostingStartup))]
namespace MatinloAdventures.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {});
        }
    }
}