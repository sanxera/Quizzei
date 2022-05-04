using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QZI.Quiz.Domain.Quiz.Repositories;
using QZI.Quiz.Infra.Data.Data;
using QZI.Quiz.Infra.Data.Data.Repository;

namespace QZI.Quiz.Infra.CrossCutting.IoC.Modules
{
    public static class DataModule
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IQuizInfoRepository, QuizInfoRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IQuestionOptionRepository, QuestionOptionRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();

            services.AddDbContext<QuizContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<QuizContext>();
        }
    }
}
