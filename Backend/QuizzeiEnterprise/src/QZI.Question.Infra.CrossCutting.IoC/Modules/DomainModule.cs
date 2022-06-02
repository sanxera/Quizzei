using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using QZI.Question.Domain.Questions.Handlers;
using QZI.Question.Domain.Questions.Handlers.Commands;
using QZI.Question.Domain.Questions.Handlers.Responses;

namespace QZI.Question.Infra.CrossCutting.IoC.Modules
{
    public static class DomainModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IRequestHandler<CreateQuestionsCommand, CreateQuestionsResponse>, QuestionCommandHandler>();
        }
    }
}
