using MathTasksCreator.Componentns.Tasks.Contracts;

namespace MathTasksCreator.Componentns.Tasks.Workers;

public sealed class SubtractWorker : IMathTaskWorker
{
    public Task Generate(ClassLevel classLevel, TaskType taskTypes)
    {
        return Task.CompletedTask;
    }
}
