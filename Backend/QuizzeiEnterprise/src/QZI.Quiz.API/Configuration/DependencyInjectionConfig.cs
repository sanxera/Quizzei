using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QZI.Quiz.Domain.Quiz.Handlers;
using QZI.Quiz.Domain.Quiz.Handlers.Commands;
using QZI.Quiz.Domain.Quiz.Handlers.Response;
using QZI.Quiz.Domain.Quiz.Repositories;
using QZI.Quiz.Infra.Data;
using QZI.Quiz.Infra.Data.Repository;

namespace QZI.Quiz.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IQuizInfoRepository, QuizInfoRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddDbContext<QuizContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<QuizContext>();

            services.AddScoped<IRequestHandler<CreateQuizInfoCommand, CreateQuizInfoResponse>, QuizInfoCommandHandler>();
            services.AddScoped<IRequestHandler<CreateCategoryCommand, CreateCategoryResponse>, CategoryCommandHandler>();
            services.AddScoped<IRequestHandler<GetAllCategoriesCommand, GetAllCategoriesResponse>, CategoryCommandHandler>();
            return services;
        }
    }
}