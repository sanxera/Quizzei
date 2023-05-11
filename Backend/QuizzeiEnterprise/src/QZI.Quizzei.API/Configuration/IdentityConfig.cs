using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Identity.Jwt;

namespace QZI.Quizzei.API.Configuration;

public static class IdentityConfig
{
    public static void AddDefaultIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentityEntityFrameworkContextConfiguration(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
                b=>b.MigrationsAssembly("Qzi.Quizzei.Api")));

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 1;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredUniqueChars = 0;
            options.Password.RequireNonAlphanumeric = false;
        });

        services.AddIdentityConfiguration();
        services.AddJwtConfiguration(configuration, "AppSettings");
    }
}