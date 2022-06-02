using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using QZI.Category.Domain.Handlers;
using QZI.Category.Domain.Handlers.Commands;
using QZI.Category.Domain.Handlers.Response;

namespace QZI.Category.Infra.CrossCutting.IoC.Modules
{
    public static class DomainModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IRequestHandler<CreateCategoryCommand, CreateCategoryResponse>, CategoryCommandHandler>();
            services.AddScoped<IRequestHandler<GetAllCategoriesCommand, GetAllCategoriesResponse>, CategoryCommandHandler>();
            services.AddScoped<IRequestHandler<GetCategoryByIdCommand, GetCategoryByIdResponse>, CategoryCommandHandler>();
        }
    }
}
