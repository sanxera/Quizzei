using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QZI.ReaderOcr.Worker;
using QZI.ReaderOcr.Worker.Ioc;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.RegisterDomain();
    }).Build();

await host.RunAsync();