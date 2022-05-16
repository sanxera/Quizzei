﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using QZI.Quiz.Domain.Quiz.Acl;
using QZI.Quiz.Domain.Quiz.Acl.Interface;
using QZI.Quiz.Domain.Quiz.Handlers;
using QZI.Quiz.Domain.Quiz.Handlers.Commands.Category;
using QZI.Quiz.Domain.Quiz.Handlers.Commands.Question;
using QZI.Quiz.Domain.Quiz.Handlers.Commands.Quiz;
using QZI.Quiz.Domain.Quiz.Handlers.Response.Category;
using QZI.Quiz.Domain.Quiz.Handlers.Response.Question;
using QZI.Quiz.Domain.Quiz.Handlers.Response.Quiz;

namespace QZI.Quiz.Infra.CrossCutting.IoC.Modules
{
    public static class DomainModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpClient<IUserServiceAcl, UserServiceAcl>();

            services.AddScoped<IRequestHandler<CreateQuizInfoCommand, CreateQuizInfoResponse>, QuizInfoCommandHandler>();
            services.AddScoped<IRequestHandler<CreateCategoryCommand, CreateCategoryResponse>, CategoryCommandHandler>();
            services.AddScoped<IRequestHandler<GetAllCategoriesCommand, GetAllCategoriesResponse>, CategoryCommandHandler>();
            services.AddScoped<IRequestHandler<CreateQuestionsCommand, CreateQuestionsResponse>, QuestionCommandHandler>();
        }
    }
}
