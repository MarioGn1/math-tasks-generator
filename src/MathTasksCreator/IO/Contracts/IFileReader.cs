namespace MathTasksCreator.IO.Contracts;

public interface IFileReader : IReader
{
    Task<string> ReadAll(string filePath);
}