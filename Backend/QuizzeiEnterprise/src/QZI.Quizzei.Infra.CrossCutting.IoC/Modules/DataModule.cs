using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QZI.Quizzei.Domain.Abstractions.UnitOfWork;
using QZI.Quizzei.Domain.Domains.Category.Repositories;
using QZI.Quizzei.Domain.Domains.Questions.Repositories;
using QZI.Quizzei.Domain.Domains.Quiz.Repositories;
using QZI.Quizzei.Infra.Data;
using QZI.Quizzei.Infra.Data.Repository;
using QZI.Quizzei.Infra.Data.UnitOfWork;

namespace QZI.Quizzei.Infra.CrossCutting.IoC.Modules
{
    public static class DataModule
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IQuizInfoRepository, QuizInfoRepository>();
            services.AddScoped<IQuizProcessRepository, QuizProcessRepository>();

            services.AddDbContext<QuizzeiContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                    options.EnableSensitiveDataLogging();
                    options.EnableDetailedErrors();
                }
            );

            services.AddScoped<QuizzeiContext>();
        }
    }
}
