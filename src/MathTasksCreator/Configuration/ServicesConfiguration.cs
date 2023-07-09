using MathTasksCreator.Application;
using MathTasksCreator.Componentns;
using MathTasksCreator.Componentns.Contracts;
using MathTasksCreator.Componentns.Menu;
using MathTasksCreator.Componentns.Tasks;
using MathTasksCreator.Componentns.Tasks.Contracts;
using MathTasksCreator.Componentns.Tasks.Workers;
using MathTasksCreator.IO;
using MathTasksCreator.IO.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace MathTasksCreator.Configuration;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
        => services
            .AddSingleton<Engine>()
            .AddTransient<IConsoleReader, CustomReader>()
            .AddTransient<IFileReader, FileReader>()
            .AddTransient<IWriter, CustomWriter>()
            .ConfigureComponents()
            .ConfigureTaskStrategy();

    private static IServiceCollection ConfigureComponents(this IServiceCollection services)
        => services
            .AddTransient<ICustomComponent<MainMenu, bool>, MainMenu>()
            .AddTransient<ICustomComponent<FirstClassMenu, bool>, FirstClassMenu>();

    private static IServiceCollection ConfigureTaskStrategy(this IServiceCollection services)
        => services
            .AddTransient<IMathTaskManager, MathTaskManager>()
            .AddTransient<IMathTaskWorker, AddWorker>()
            .AddTransient<IMathTaskWorker, SubtractWorker>()
            .AddTransient<IMathTaskWorker, AddSubtractWorker>()
            .AddTransient<IMathTaskWorker, CompareWorker>();
}