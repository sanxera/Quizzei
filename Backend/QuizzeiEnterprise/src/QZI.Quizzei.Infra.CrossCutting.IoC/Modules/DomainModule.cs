using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using QZI.Quizzei.Domain.Domains.Category.Service;
using QZI.Quizzei.Domain.Domains.Category.Service.Abstractions;
using QZI.Quizzei.Domain.Domains.Questions.Services;
using QZI.Quizzei.Domain.Domains.Questions.Services.Abstractions;
using QZI.Quizzei.Domain.Domains.Quiz.Services;
using QZI.Quizzei.Domain.Domains.Quiz.Services.Abstractions;
using QZI.Quizzei.Domain.Domains.User.Service;
using QZI.Quizzei.Domain.Domains.User.Service.Abstractions;

namespace QZI.Quizzei.Infra.CrossCutting.IoC.Modules
{
    public static class DomainModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IQuizProcessService, QuizProcessService>();
            services.AddScoped<IQuizInformationService, QuizInformationService>();
        }
    }
}
