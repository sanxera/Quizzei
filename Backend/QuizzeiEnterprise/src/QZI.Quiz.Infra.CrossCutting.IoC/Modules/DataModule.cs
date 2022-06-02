using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QZI.Quiz.Domain.Quiz.Repositories;
using QZI.Quiz.Domain.Quiz.UnitOfWork;
using QZI.Quiz.Infra.Data.Data;
using QZI.Quiz.Infra.Data.Data.Repository;
using QZI.Quiz.Infra.Data.Data.UnitOfWork;

namespace QZI.Quiz.Infra.CrossCutting.IoC.Modules
{
    public static class DataModule
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IQuizInfoRepository, QuizInfoRepository>();

            services.AddDbContext<QuizContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                    options.EnableSensitiveDataLogging();
                    options.EnableDetailedErrors();
                }
            );

            services.AddScoped<QuizContext>();
        }
    }
}
