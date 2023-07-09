namespace MathTasksCreator.Componentns.Tasks.Contracts;

public interface IMathTaskWorker
{
    Task Generate(ClassLevel classLevel, TaskType taskTypes);
}
