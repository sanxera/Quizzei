using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using QZI.User.Domain.User.Handlers;
using QZI.User.Domain.User.Handlers.Commands;
using QZI.User.Domain.User.Handlers.Responses;
using QZI.User.Domain.User.Services;
using QZI.User.Domain.User.Services.Interfaces;

namespace QZI.User.Infra.CrossCutting.IoC.Modules
{
    public static class DomainModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpClient<IAuthUserService, AuthUserService>();
            services.AddScoped<IRequestHandler<CreateUserCommand, CreateUserResponse>, UserIdentityCommandHandler>();
            services.AddScoped<IRequestHandler<LoginUserCommand, LoginUserResponse>, UserIdentityCommandHandler>();
        }
    }
}
