namespace MathTasksCreator.IO.Contracts;

public interface IReader
{
    Task<string?> ReadLine();
}