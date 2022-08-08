using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using QZI.Quizzei.Domain.Domains.Category.Handlers;
using QZI.Quizzei.Domain.Domains.Category.Handlers.Commands;
using QZI.Quizzei.Domain.Domains.Category.Handlers.Response;
using QZI.Quizzei.Domain.Domains.Questions.Handlers;
using QZI.Quizzei.Domain.Domains.Questions.Handlers.Commands;
using QZI.Quizzei.Domain.Domains.Questions.Handlers.Responses;
using QZI.Quizzei.Domain.Domains.Quiz.Handlers;
using QZI.Quizzei.Domain.Domains.Quiz.Handlers.Commands;
using QZI.Quizzei.Domain.Domains.Quiz.Handlers.Commands.Process;
using QZI.Quizzei.Domain.Domains.Quiz.Handlers.Response;
using QZI.Quizzei.Domain.Domains.Quiz.Handlers.Response.Process;
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

            services.AddScoped<IRequestHandler<CreateCategoryCommand, CreateCategoryResponse>, CategoryCommandHandler>();
            services.AddScoped<IRequestHandler<GetAllCategoriesCommand, GetAllCategoriesResponse>, CategoryCommandHandler>();
            services.AddScoped<IRequestHandler<GetCategoryByIdCommand, GetCategoryByIdResponse>, CategoryCommandHandler>();

            services.AddScoped<IRequestHandler<CreateQuestionsCommand, CreateQuestionsResponse>, QuestionCommandHandler>();
            services.AddScoped<IRequestHandler<GetQuestionsWithOptionsByQuizCommand, GetQuestionsWithOptionsByQuizResponse>, QuestionCommandHandler>();
            services.AddScoped<IRequestHandler<AnswerQuestionCommand, AnswerQuestionResponse>, AnswerCommandHandler>();

            services.AddScoped<IRequestHandler<CreateQuizInfoCommand, CreateQuizInfoResponse>, QuizInfoCommandHandler>();
            services.AddScoped<IRequestHandler<GetQuizzesInfoByUserCommand, GetQuizzesInfoByUserResponse>, QuizInfoCommandHandler>();
            services.AddScoped<IRequestHandler<GetQuizzesInfoByDifferentUsersCommand, GetQuizzesInfoByDifferentUsersResponse>, QuizInfoCommandHandler>();
            services.AddScoped<IRequestHandler<StartQuizProcessCommand, StartQuizProcessResponse>, QuizProcessCommandHandler>();
        }
    }
}
