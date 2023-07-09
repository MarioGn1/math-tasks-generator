using MathTasksCreator.IO.Contracts;
using System.Text;

namespace MathTasksCreator.IO;

public sealed class CustomWriter : IWriter
{
    public CustomWriter()
    {
        Console.OutputEncoding = Encoding.UTF8;
    }

    public Task WriteLine(string text)
    {
        Console.WriteLine(text);

        return Task.CompletedTask;
    }

    public Task Write(string text)
    {
        Console.Write(text);

        return Task.CompletedTask;
    }

    public Task Clear()
    {
        Console.Clear();

        return Task.CompletedTask;
    }
}