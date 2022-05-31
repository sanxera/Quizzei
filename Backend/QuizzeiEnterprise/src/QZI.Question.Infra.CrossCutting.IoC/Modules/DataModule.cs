using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QZI.Question.Domain.Questions.Repositories;
using QZI.Question.Domain.Questions.UnitOfWork;
using QZI.Question.Infra.Data;
using QZI.Question.Infra.Data.Repository;
using QZI.Question.Infra.Data.UnitOfWork;

namespace QZI.Question.Infra.CrossCutting.IoC.Modules
{
    public static class DataModule
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IQuestionRepository, QuestionRepository>();

            services.AddDbContext<QuestionContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                    options.EnableSensitiveDataLogging();
                    options.EnableDetailedErrors();
                }
            );

            services.AddScoped<QuestionContext>();
        }
    }
}
