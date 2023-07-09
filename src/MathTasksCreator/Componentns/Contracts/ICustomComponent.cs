namespace MathTasksCreator.Componentns.Contracts;

public interface ICustomComponent<TComponent>
    where TComponent : class
{
    public Task Render();
}

public interface ICustomComponent<TComponent, TResult>
    where TComponent : class
{
    public Task<TResult> Render();
}
