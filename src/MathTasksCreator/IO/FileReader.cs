using MathTasksCreator.IO.Contracts;

namespace MathTasksCreator.IO;

public class FileReader : IFileReader
{
    public Task<string?> ReadLine()
    {
        return null!;
    }

    public Task<string> ReadAll(string filePath)
        => Task.FromResult(File.ReadAllText(filePath));
}