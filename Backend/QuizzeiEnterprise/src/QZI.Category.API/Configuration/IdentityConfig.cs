using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Identity;
using NetDevPack.Identity.Jwt;

namespace QZI.Category.API.Configuration
{
    public static class IdentityConfig
    {
        public static void AddDefaultIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityEntityFrameworkContextConfiguration(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
                    b=>b.MigrationsAssembly("Qzi.Category.Api")));

            services.AddIdentityConfiguration();
            services.AddJwtConfiguration(configuration, "AppSettings");
        }
    }
}