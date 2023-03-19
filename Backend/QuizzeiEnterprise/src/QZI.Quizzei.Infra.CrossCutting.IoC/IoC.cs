using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QZI.Quizzei.Infra.CrossCutting.IoC.Modules;

namespace QZI.Quizzei.Infra.CrossCutting.IoC;

public static class IoC
{
    public static void RegisterModules(this IServiceCollection services, IConfiguration configuration)
    {
        DomainModule.Register(services, configuration);
        DataModule.Register(services, configuration);
    }
}