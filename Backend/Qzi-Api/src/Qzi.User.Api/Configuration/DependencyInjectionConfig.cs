using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Qzi.User.Domain.User.Handlers;
using Qzi.User.Domain.User.Handlers.Commands;
using Qzi.User.Domain.User.Handlers.Responses;

namespace Qzi.User.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IRequestHandler<CreateUserCommand, CreateUserResponse>, UserCommandHandler>();
            return services;
        }
    }
}