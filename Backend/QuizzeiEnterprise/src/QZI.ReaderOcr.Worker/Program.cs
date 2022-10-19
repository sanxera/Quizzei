using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QZI.ReaderOcr.Worker;
using QZI.ReaderOcr.Worker.CrossCuttingIoc;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddHostedService<Worker>();
        services.RegisterDomain();
        services.RegisterDataModule(context.Configuration);
    })
    .ConfigureHostConfiguration(x =>
    {
        x.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .AddEnvironmentVariables();
    })
    .Build();

await host.RunAsync();