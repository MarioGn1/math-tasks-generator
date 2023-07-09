using MathTasksCreator.Componentns.Tasks.Contracts;

namespace MathTasksCreator.Componentns.Tasks;

public sealed class MathTaskManager : IMathTaskManager
{
    private readonly IEnumerable<IMathTaskWorker> _workers;

    public MathTaskManager(IEnumerable<IMathTaskWorker> workers)
    {
        _workers = workers;
    }

    public async Task Generate(ClassLevel classLevel, TaskType taskTypes)
    {
        foreach (var worker in _workers)
        {
            await worker.Generate(classLevel, taskTypes);
        }
    }
}
