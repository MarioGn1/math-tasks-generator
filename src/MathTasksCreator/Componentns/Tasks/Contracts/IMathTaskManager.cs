namespace MathTasksCreator.Componentns.Tasks.Contracts;

public interface IMathTaskManager
{
    Task Generate(ClassLevel classLevel, TaskType taskTypes);
}
