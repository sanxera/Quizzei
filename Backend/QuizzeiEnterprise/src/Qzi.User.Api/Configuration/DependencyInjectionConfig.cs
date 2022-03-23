using MediatR;
using Microsoft.Extensions.DependencyInjection;
using QZI.User.Domain.User.Handlers;
using QZI.User.Domain.User.Handlers.Commands;
using QZI.User.Domain.User.Handlers.Responses;
using QZI.User.Domain.User.Repositories;
using QZI.User.Infra.Data;
using QZI.User.Infra.Data.Repository;

namespace QZI.User.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<CreateUserCommand, CreateUserResponse>, UserCommandHandler>();

            //Data
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<QuizzeiContext>();
            return services;
        }
    }
}