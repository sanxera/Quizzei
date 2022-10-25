using Microsoft.Extensions.DependencyInjection;
using QZI.ReaderOcr.Worker.Domain.Services;
using QZI.ReaderOcr.Worker.Domain.Services.Abstractions;

namespace QZI.ReaderOcr.Worker.CrossCuttingIoc
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
