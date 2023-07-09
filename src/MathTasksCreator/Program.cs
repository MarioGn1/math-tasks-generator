using MathTasksCreator.Application;
using MathTasksCreator.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = HostBuilder(args).Build();

var app = host.Services.GetRequiredService<Engine>();
await app.Run();

static IHostBuilder HostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices(
            (_, services) =>
                services.ConfigureServices());
}
