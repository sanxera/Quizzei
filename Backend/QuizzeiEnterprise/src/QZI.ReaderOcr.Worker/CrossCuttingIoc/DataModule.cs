using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QZI.ReaderOcr.Worker.Data;
using QZI.ReaderOcr.Worker.Data.Repositories;
using QZI.ReaderOcr.Worker.Data.UnitOfWork;
using QZI.ReaderOcr.Worker.Domain.Abstractions.UnitOfWork;
using QZI.ReaderOcr.Worker.Domain.Repositories;

namespace QZI.ReaderOcr.Worker.CrossCuttingIoc
{
    public static class DataModule
    {
        public static void RegisterDataModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IOcrQuestionRepository, OcrQuestionRepository>();
            services.AddScoped<IOcrQuestionOptionRepository, OcrQuestionOptionRepository>();

            services.AddDbContext<QuizzeiOcrContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                    options.EnableSensitiveDataLogging();
                    options.EnableDetailedErrors();
                }
            );

            services.AddScoped<QuizzeiOcrContext>();
        }
    }
}