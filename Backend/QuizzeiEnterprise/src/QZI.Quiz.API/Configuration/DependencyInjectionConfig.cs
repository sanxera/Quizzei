using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace QZI.Quiz.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddHttpClient<IAuthUserService, AuthUserService>();
            //services.AddScoped<IUserRepository, UserRepository>();

            //services.AddDbContext<QuizzeiContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //services.AddScoped<QuizzeiContext>();

            //services.AddScoped<IRequestHandler<CreateUserCommand, CreateUserResponse>, UserIdentityCommandHandler>();
            //services.AddScoped<IRequestHandler<LoginUserCommand, LoginUserResponse>, UserIdentityCommandHandler>();
 
            return services;
        }
    }
}