using DiscordBot.Core.Services.CustomCommands;
using DiscordBot.Core.Services.Items;
using DiscordBot.Core.Services.Profiles;
using DiscordBot.Core.Services.Quotes;
using DiscordBot.Core.Services.ReactionRoles;
using DiscordBot.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DiscordBot.Bots
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var SqlServerConnectionString = Configuration["connectionstring"];

            services.AddDbContext<RPGContext>(options =>
            {
                options.UseSqlServer(SqlServerConnectionString,
                   x => x.MigrationsAssembly("DiscordBot.DAL.Migrations"));
            });
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IExperienceService, ExperienceService>();
            services.AddScoped<IGoldService, GoldService>();
            services.AddScoped<ICustomCommandService, CustomCommandService>();
            services.AddScoped<IQuoteService, QuoteService>();
            services.AddScoped<IReactionRoleService, ReactionRoleService>();
            services.AddRazorPages();

            var serviceProvider = services.BuildServiceProvider();

            var bot = new Bot(serviceProvider, Configuration);
            services.AddSingleton(bot);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
