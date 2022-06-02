using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using QZI.Quiz.Domain.Quiz.Acl;
using QZI.Quiz.Domain.Quiz.Acl.Interface;
using QZI.Quiz.Domain.Quiz.Handlers;
using QZI.Quiz.Domain.Quiz.Handlers.Commands;
using QZI.Quiz.Domain.Quiz.Handlers.Commands.Process;
using QZI.Quiz.Domain.Quiz.Handlers.Response;
using QZI.Quiz.Domain.Quiz.Handlers.Response.Process;

namespace QZI.Quiz.Infra.CrossCutting.IoC.Modules
{
    public static class DomainModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpClient<IUserServiceAcl, UserServiceAcl>();
            services.AddHttpClient<ICategoryServiceAcl, CategoryServiceAcl>();

            services.AddScoped<IRequestHandler<CreateQuizInfoCommand, CreateQuizInfoResponse>, QuizInfoCommandHandler>();
            services.AddScoped<IRequestHandler<GetQuizzesInfoByUserCommand, GetQuizzesInfoByUserResponse>, QuizInfoCommandHandler>();
            services.AddScoped<IRequestHandler<StartQuizProcessCommand, StartQuizProcessResponse>, QuizProcessCommandHandler>();
        }
    }
}
