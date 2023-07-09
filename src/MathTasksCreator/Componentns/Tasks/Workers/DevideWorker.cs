using MathTasksCreator.Componentns.Tasks.Contracts;

namespace MathTasksCreator.Componentns.Tasks.Workers;

public sealed class DevideWorker : IMathTaskWorker
{
    public Task Generate(ClassLevel classLevel, TaskType taskTypes)
    {
        return Task.CompletedTask;
    }
}
