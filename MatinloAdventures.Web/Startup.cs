using System;
using System.Threading.Tasks;
using MatinloAdventures.Data;
using MatinloAdventures.Data.Helpers;
using MatinloAdventures.Data.Models;
using MatinloAdventures.Services;
using MatinloAdventures.Services.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MatinloAdventures.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<MatinloAdventuresDbContext>(options =>
                {
                    options.UseLazyLoadingProxies().UseSqlServer(
                        Configuration.GetConnectionString("DefaultConnection"));
                }
            );

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    // Password settings
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 3;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequiredUniqueChars = 2;

                    //user settings
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<MatinloAdventuresDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "OnlineFishShopCookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
                // Requires `using Microsoft.AspNetCore.Authentication.Cookies;`
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
            });

            services.AddTransient<IGenericDataService<BlogPost>, GenericDataService<BlogPost>>();
            services.AddTransient<IGenericDataService<BlogComment>, GenericDataService<BlogComment>>();
            services.AddTransient<IGenericDataService<Faq>, GenericDataService<Faq>>();
            services.AddTransient<IGenericDataService<TourPackage>, GenericDataService<TourPackage>>();
            services.AddTransient<IGenericDataService<TourPackageComment>, GenericDataService<TourPackageComment>>();

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddMvc(options => { options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>(); })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //scope seed db
            using (var serviceScope =
                app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<MatinloAdventuresDbContext>();
                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                context.Database.Migrate();

                CreateRoles(serviceProvider).Wait();

                context.EnsureSeedData(Task.Run(() => userManager.FindByNameAsync("admin")).GetAwaiter().GetResult());
            }
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            //initializing custom roles 
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string[] roleNames = { "Admin", "Manager" };

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                    await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            //Here you could create a super user who will maintain the web app
            var username = this.Configuration.GetSection("UserSettings")["AdminUsername"];
            var email = this.Configuration.GetSection("UserSettings")["AdminEmail"];

            var superUser = new ApplicationUser
            {
                UserName = username,
                Email = email
            };

            //Ensure you have these values in your appsettings.json or secrets.json file
            var userPwd = this.Configuration.GetSection("UserSettings")["AdminPassword"];
            var user = await userManager.FindByNameAsync(
                this.Configuration.GetSection("UserSettings")["AdminUsername"]);

            if (user == null)
            {
                var createSuperUser = await userManager.CreateAsync(superUser, userPwd);
                if (createSuperUser.Succeeded)
                    await userManager.AddToRoleAsync(superUser, "Admin");
            }
        }
    }
}
