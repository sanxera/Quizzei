using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QZI.Category.Domain.Repositories;
using QZI.Category.Domain.UnitOfWork;
using QZI.Category.Infra.Data;
using QZI.Category.Infra.Data.Repository;
using QZI.Category.Infra.Data.UnitOfWork;

namespace QZI.Category.Infra.CrossCutting.IoC.Modules
{
    public static class DataModule
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddDbContext<CategoryContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                    options.EnableSensitiveDataLogging();
                    options.EnableDetailedErrors();
                }
            );

            services.AddScoped<CategoryContext>();
        }
    }
}
