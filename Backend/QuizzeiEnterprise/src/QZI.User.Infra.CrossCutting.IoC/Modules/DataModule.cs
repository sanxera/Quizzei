using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QZI.User.Domain.User.Repositories;
using QZI.User.Infra.Data.Data;
using QZI.User.Infra.Data.Data.Repository;

namespace QZI.User.Infra.CrossCutting.IoC.Modules
{
    public static class DataModule
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddDbContext<UserContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                    options.EnableSensitiveDataLogging();
                    options.EnableDetailedErrors();
                }
            );

            services.AddScoped<UserContext>();
        }
    }
}
