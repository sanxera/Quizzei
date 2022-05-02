using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QZI.Quiz.Infra.CrossCutting.IoC.Modules;

namespace QZI.Quiz.Infra.CrossCutting.IoC
{
    public static class IoC
    {
        public static void RegisterModules(this IServiceCollection services, IConfiguration configuration)
        {
            DomainModule.Register(services);
            DataModule.Register(services, configuration);
        }
    }
}
