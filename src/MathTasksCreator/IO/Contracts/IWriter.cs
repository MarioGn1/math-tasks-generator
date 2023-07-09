namespace MathTasksCreator.IO.Contracts;

public interface IWriter
{
    Task WriteLine(string text = default!);
    Task Write(string text);
    Task Clear();
}