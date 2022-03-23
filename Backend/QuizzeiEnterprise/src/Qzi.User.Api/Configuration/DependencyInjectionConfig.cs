using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using QZI.User.Domain.User.Handlers;
using QZI.User.Domain.User.Handlers.Commands;
using QZI.User.Domain.User.Handlers.Responses;
using QZI.User.Domain.User.Repositories;
using QZI.User.Domain.User.Services;
using QZI.User.Domain.User.Services.Interfaces;
using QZI.User.Infra.Data;
using QZI.User.Infra.Data.Repository;

namespace QZI.User.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpClient<IAuthUserService, AuthUserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<QuizzeiContext>();

            services.AddScoped<IRequestHandler<CreateUserCommand, CreateUserResponse>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<UserLoginCommand, UserLoginResponse>, UserCommandHandler>();
 
            return services;
        }
    }
}