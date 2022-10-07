using Microsoft.Extensions.DependencyInjection;
using QZI.ReaderOcr.Worker.Services;
using QZI.ReaderOcr.Worker.Services.Abstractions;

namespace QZI.ReaderOcr.Worker.Ioc
{
    public static class DomainModule
    {
        public static void RegisterDomain(this IServiceCollection services)
        {
            services.AddScoped<ITokenSplitService, TokenSplitService>();
            services.AddScoped<IOcrService, OcrService>();
        }
    }
}
